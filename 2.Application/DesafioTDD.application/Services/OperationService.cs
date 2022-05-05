using System;
using System.Collections.Generic;
using System.Linq;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Helpers;
using DesafioTDD.application.Interfaces;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;

namespace DesafioTDD.application.Services
{
    public class OperationService : IOperationService
    {
        private IOperationRepository _operationRepository;
        private ICustomerRepository _customerRepository;
        private ICashMachineRepository _cashMachineRepository;
        private OperationHelper _operationHelper;

        public OperationService(IOperationRepository operationRepository, ICustomerRepository customerRepository, ICashMachineRepository cashMachineRepository, OperationHelper operationHelper)
        {
            _operationRepository = operationRepository;
            _customerRepository = customerRepository;
            _cashMachineRepository = cashMachineRepository;
            _operationHelper = operationHelper;
        }

        public List<object> GetOperations(int customerId)
        {
            var operations = _operationRepository.GetOperations(customerId);
            if (!operations.Any())
                throw new ArgumentException("Nenhuma operação efetuada");

            var statementList = new List<object>();
            foreach (var operation in operations)
            {
                statementList.Add(new
                { 
                    date = operation.Date.ToString("dd/MM/yyyy H:mm:ss"),
                    name = operation.Customer.Name,
                    bank = operation.Customer.Bank.Name,
                    value = operation.TotalValue.ToString("c")
                });
            }

            return statementList;
        }

        public void OperationDeposit(CellsDto cellsDto, int cashMachineId, int userId)
        {
            var cashMachine = _cashMachineRepository.GetCashMachine(cashMachineId);
            if (cashMachine is null)
                throw new ArgumentException("Caixa eletrônico não encontrado");

            var customer = _customerRepository.GetCustomer(userId);
            if (customer is null)
                throw new ArgumentException("Cliente não encontrado");

            if(cashMachine.Bank.Id != customer.Bank.Id)
                throw new Exception("Caixa eletrônico incompatível com banco do cliente");

            _operationHelper.InsertCash(cashMachine, cellsDto);
            _cashMachineRepository.UpdateCashMachine(cashMachine);

            var totalValue = _operationHelper.SumValue(cellsDto);
            customer.Balance += totalValue;
            _customerRepository.UpdateCustomer(customer);

            //-------------------- Registra a operação financeira --------------------

            Operation operation = new Operation()
            {
                Customer = customer,
                CashMachine = cashMachine,
                TotalValue = totalValue,
                Date = DateTime.Now
            };
            _operationRepository.CreateOperation(operation);
        }

        public OperationWithdrawDto OperationWithdraw(decimal totalValue, int cashMachineId, int userId)
        {
            var cashMachine = _cashMachineRepository.GetCashMachine(cashMachineId);
            if (cashMachine is null)
                throw new ArgumentException("Caixa eletrônico não encontrado");

            var customer = _customerRepository.GetCustomer(userId);
            if (customer is null)
                throw new ArgumentException("Cliente não encontrado");

            if (cashMachine.Bank.Id != customer.Bank.Id)
                throw new Exception("Caixa eletrônico incompatível com banco do cliente");

            if (customer.Balance < totalValue)
                throw new Exception("Saldo insuficiente");

            if (cashMachine.TotalValue < totalValue)
                throw new Exception("Valor indisponível no caixa eletrônico");

            var operationWithdrawDto = _operationHelper.ConvertToCells(cashMachine, totalValue);
            
            _cashMachineRepository.UpdateCashMachine(cashMachine);

            customer.Balance -= operationWithdrawDto.WithdrawValue;
            _customerRepository.UpdateCustomer(customer);

            //-------------------- Registra a operação financeira --------------------
            
            Operation operation = new Operation()
            {
                Customer = customer,
                CashMachine = cashMachine,
                TotalValue = (operationWithdrawDto.WithdrawValue * -1),
                Date = DateTime.Now
            };
            _operationRepository.CreateOperation(operation);

            return operationWithdrawDto;
        }
    }
}
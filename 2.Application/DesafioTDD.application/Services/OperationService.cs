using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public OperationService(IOperationRepository operationRepository, ICustomerRepository customerRepository, ICashMachineRepository cashMachineRepository)
        {
            _operationRepository = operationRepository;
            _customerRepository = customerRepository;
            _cashMachineRepository = cashMachineRepository;
        }

        public Operation GetOperation(int id)
        {
            var operation = _operationRepository.GetOperation(id);
            if (operation is null)
                throw new ArgumentException("Operação não encontrada");

            return operation;
        }

        public List<Operation> GetOperations(int customerId)
        {
            var operations = _operationRepository.GetOperations(customerId);
            if (!operations.Any())
                throw new ArgumentException("Nenhume operação efetuada");

            return operations;
        }

        public void OperationDeposit(OperationCellsDto operationDto, int cashMachineId, int userId)
        {
            var cashMachine = _cashMachineRepository.GetCashMachine(cashMachineId);
            if (cashMachine is null)
                throw new ArgumentException("Caixa eletrônico não encontrado");

            var customer = _customerRepository.GetCustomer(userId);
            if (customer is null)
                throw new ArgumentException("Cliente não encontrado");

            if(cashMachine.Bank.Id != customer.Bank.Id)
                throw new Exception("Caixa eletrônico incompatível com banco do cliente");

            OperationHelper.InsertCash(cashMachine, operationDto);
            _cashMachineRepository.UpdateCashMachine(cashMachine);

            var totalValue = OperationHelper.SumValue(operationDto);
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

            if(cashMachine.Bank.Id != customer.Bank.Id)
                throw new Exception("Caixa eletrônico incompatível com banco do cliente");

            if (cashMachine.TotalValue < totalValue)
                throw new Exception("Valor indisponível");

            var operationWithdrawDto = OperationHelper.ConvertToCells(cashMachine, totalValue);
            
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
using System;
using System.Collections.Generic;
using System.Linq;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Helpers;
using DesafioTDD.application.Interfaces;
using DesafioTDD.application.Mappers;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;

namespace DesafioTDD.application.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private IBankRepository _bankRepository;
        private ICashMachineRepository _cashMachineRepository;
        private CardNumberHelper _cardNumberHelper;

        public CustomerService(ICustomerRepository customerRepository, IBankRepository bankRepository, ICashMachineRepository cashMachineRepository, CardNumberHelper cardNumberHelper)
        {
            _customerRepository = customerRepository;
            _bankRepository = bankRepository;
            _cashMachineRepository = cashMachineRepository;
            _cardNumberHelper = cardNumberHelper;
        }

        public object CustomerRegister(CustomerRegisterDto customerDto)
        {
            var bank = _bankRepository.GetBank(customerDto.BankId);
            if (bank is null)
                throw new ArgumentException("Banco não encontrado");

            var cardNumber = _cardNumberHelper.GenerateCardNumber(bank.CardNumberPrefix);
            var customer = customerDto.ToDomain();
            customer.Bank = bank;
            customer.CardNumber = cardNumber;

            _customerRepository.CreateCustomer(customer);

            var cashMachines = _cashMachineRepository.GetCashMachines().Where(e => e.Bank.Id == bank.Id);
            var cashMachinesIds = new List<int>();
            foreach (var cashMachine in cashMachines)
            {
                cashMachinesIds.Add(cashMachine.Id);
            }

            if (cashMachines is null)
                return new
                    {
                        cardNumber = cardNumber,
                        cashMachines = "Nenhum caixa eletrônico encontrado"
                    };

            return new
            {
                cardNumber = cardNumber,
                cashMachines = cashMachinesIds
            };
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer is null)
                throw new ArgumentException("Cliente não encontrado");

            if (customer.Balance > 0m)
                throw new Exception("Não é possível deletar um cliente com saldo");

            _customerRepository.DeleteCustomer(customer);
        }

        public Customer GetCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer is null)
                throw new ArgumentException("Cliente não encontrado");

            return customer;
        }

        public List<Customer> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            if (!customers.Any())
                throw new ArgumentException("Nenhum cliente cadastrado");

            return customers;
        }

        public Customer LoginCustomer(string cardNumber, string password)
        {
            var customer = _customerRepository.LoginCustomer(cardNumber, password);
            if (customer is null)
                throw new ArgumentException("Credenciais incorretas");

            return customer;
        }

        public void UpdateCustomer(CustomerUpdateDto customerDto, int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer is null)
                throw new ArgumentException("Cliente não encontrado");
                
            customer.Name = customerDto.Name ?? customer.Name;
            customer.Password = customerDto.Password ?? customer.Password;

            _customerRepository.UpdateCustomer(customer);
        }
    }
}
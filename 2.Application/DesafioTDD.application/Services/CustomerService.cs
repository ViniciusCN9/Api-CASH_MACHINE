using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CustomerService(ICustomerRepository customerRepository, IBankRepository bankRepository)
        {
            _customerRepository = customerRepository;
            _bankRepository = bankRepository;
        }

        public void CustomerRegister(CustomerRegisterDto customerDto)
        {
            var bank = _bankRepository.GetBank(customerDto.BankId);
            if (bank is null)
                throw new ArgumentException("Banco não encontrado");

            var customer = customerDto.ToDomain();
            customer.Bank = bank;
            customer.CardNumber = CardNumberHelper.GenerateCardNumber(bank.CardNumberPrefix);

            _customerRepository.CreateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer is null)
                throw new ArgumentException("Cliente não encontrado");

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
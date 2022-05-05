using System.Collections.Generic;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer LoginCustomer(string cardNumber, string password);
        object CustomerRegister(CustomerRegisterDto customerDto);
        void UpdateCustomer(CustomerUpdateDto customerDto, int id);
        void DeleteCustomer(int Id);
    }
}
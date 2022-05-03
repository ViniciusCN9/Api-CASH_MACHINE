using System.Collections.Generic;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.domain.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer LoginCustomer(string cardNumber, string password);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

    }
}
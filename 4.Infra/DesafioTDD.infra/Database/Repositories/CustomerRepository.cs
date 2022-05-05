using System.Collections.Generic;
using System.Linq;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;
using DesafioTDD.infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioTDD.infra.Database.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            Customer customer;
            try
            {
                customer = _context.Customers.Include(e => e.Bank).FirstOrDefault(e => e.Id == id);
            }
            catch
            {
                customer = null;
            }

            return customer;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers;
            try
            {
                customers = _context.Customers.Include(e => e.Bank).ToList();
            }
            catch
            {
                customers = null;
            }

            return customers;
        }

        public Customer LoginCustomer(string cardNumber, string password)
        {
            Customer customer;
            try
            {
                customer = _context.Customers.Include(e => e.Bank).FirstOrDefault(e => e.CardNumber == cardNumber && e.Password == password);
            }
            catch
            {
                customer = null;
            }

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
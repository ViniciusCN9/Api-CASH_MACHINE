using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;
using DesafioTDD.infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioTDD.infra.Database.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ApplicationDbContext _context;
        
        public OperationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void CreateOperation(Operation operation)
        {
            _context.Operations.Add(operation);
            _context.SaveChanges();
        }

        public Operation GetOperation(int id)
        {
            Operation operation;
            try
            {
                operation = _context.Operations.Include(e => e.Customer).Include(e => e.CashMachine).FirstOrDefault(e => e.Id == id);
            }
            catch
            {
                operation = null;
            }

            return operation;
        }

        public List<Operation> GetOperations(int customerId)
        {
            List<Operation> operations;
            try
            {
                operations = _context.Operations.Include(e => e.Customer).Include(e => e.CashMachine).Where(e => e.Customer.Id == customerId).ToList();
            }
            catch
            {
                operations = null;
            }

            return operations;
        }
    }
}
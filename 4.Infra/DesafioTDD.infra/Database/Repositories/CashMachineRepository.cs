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
    public class CashMachineRepository : ICashMachineRepository
    {
        private readonly ApplicationDbContext _context;
        
        public CashMachineRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void CreateCashMachine(CashMachine cashMachine)
        {
            _context.CashMachines.Add(cashMachine);
            _context.SaveChanges();
        }

        public void DeleteCashMachine(CashMachine cashMachine)
        {
            _context.CashMachines.Add(cashMachine);
            _context.SaveChanges();
        }

        public CashMachine GetCashMachine(int id)
        {
            CashMachine cashMachine;
            try
            {
                cashMachine = _context.CashMachines.Include(e => e.Bank).FirstOrDefault(e => e.Id == id);
            }
            catch
            {
                cashMachine = null;
            }

            return cashMachine;
        }

        public List<CashMachine> GetCashMachines()
        {
            List<CashMachine> cashMachines;
            try
            {
                cashMachines = _context.CashMachines.Include(e => e.Bank).ToList();
            }
            catch
            {
                cashMachines = null;
            }

            return cashMachines;
        }

        public void UpdateCashMachine(CashMachine cashMachine)
        {
            _context.CashMachines.Add(cashMachine);
            _context.SaveChanges();
        }
    }
}
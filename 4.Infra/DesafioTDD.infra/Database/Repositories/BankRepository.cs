using System.Collections.Generic;
using System.Linq;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;
using DesafioTDD.infra.Database.Context;

namespace DesafioTDD.infra.Database.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly ApplicationDbContext _context;
        
        public BankRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateBank(Bank bank)
        {
            _context.Banks.Add(bank);
            _context.SaveChanges();
        }

        public void DeleteBank(Bank bank)
        {
            _context.Banks.Remove(bank);
            _context.SaveChanges();
        }

        public Bank GetBank(int id)
        {
            Bank bank;
            try
            {
                bank = _context.Banks.FirstOrDefault(e => e.Id == id);
            }
            catch
            {
                bank = null;
            }

            return bank;
        }

        public List<Bank> GetBanks()
        {
            List<Bank> banks;
            try
            {
                banks = _context.Banks.ToList();
            }
            catch
            {
                banks = null;
            }

            return banks;
        }

        public void UpdateBank(Bank bank)
        {
            _context.Banks.Update(bank);
            _context.SaveChanges();
        }

        public Bank GetBankByPrefix(string prefix)
        {
            Bank bank;
            try
            {
                bank = _context.Banks.FirstOrDefault(e => e.CardNumberPrefix.Contains(prefix));
            }
            catch
            {
                bank = null;
            }

            return bank;
        }
    }
}
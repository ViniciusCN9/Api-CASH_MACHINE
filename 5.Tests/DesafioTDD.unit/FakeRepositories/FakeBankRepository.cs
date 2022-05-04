using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;

namespace DesafioTDD.unit.FakeRepositories
{
    public class FakeBankRepository : IBankRepository
    {
        public void CreateBank(Bank bank)
        {
            throw new NotImplementedException();
        }

        public void DeleteBank(Bank bank)
        {
            throw new NotImplementedException();
        }

        public Bank GetBank(int id)
        {
            throw new NotImplementedException();
        }

        public Bank GetBankByPrefix(string cardNumberPrefix)
        {
            if (cardNumberPrefix == "1234")
                return new Bank(){ CardNumberPrefix = "1234" };

            return null;
        }

        public List<Bank> GetBanks()
        {
            throw new NotImplementedException();
        }

        public void UpdateBank(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
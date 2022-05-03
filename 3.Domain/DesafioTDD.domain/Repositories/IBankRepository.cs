using System.Collections.Generic;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.domain.Repositories
{
    public interface IBankRepository
    {
        List<Bank> GetBanks();
        Bank GetBank(int id);
        void CreateBank(Bank bank);
        void UpdateBank(Bank bank);
        void DeleteBank(Bank bank);
        Bank GetBankByPrefix(string cardNumberPrefix);
    }
}
using System.Collections.Generic;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Interfaces
{
    public interface IBankService
    {
        List<Bank> GetBanks();
        Bank GetBank(int id);
        void CreateBank(BankCreateDto bankDto);
        void UpdateBank(BankUpdateDto bankDto, int id);
        void DeleteBank(int id);
    }
}
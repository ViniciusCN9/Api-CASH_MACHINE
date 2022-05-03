using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
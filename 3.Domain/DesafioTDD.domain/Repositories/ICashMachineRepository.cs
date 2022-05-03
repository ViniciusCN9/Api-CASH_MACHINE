using System.Collections.Generic;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.domain.Repositories
{
    public interface ICashMachineRepository
    {
        List<CashMachine> GetCashMachines();
        CashMachine GetCashMachine(int id);
        void CreateCashMachine(CashMachine cashMachine);
        void UpdateCashMachine(CashMachine cashMachine);
        void DeleteCashMachine(CashMachine cashMachine);
    }
}
using System.Collections.Generic;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Interfaces
{
    public interface ICashMachineService
    {
        List<CashMachine> GetCashMachines();
        CashMachine GetCashMachine(int id);
        void CreateCashMachine(CashMachineCreateDto cashMachineDto);
        void InsertCash(CellsDto operationDto, int id);
        void RetrieveCash(CellsDto operationDto, int id);
        void DeleteCashMachine(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Interfaces
{
    public interface ICashMachineService
    {
        List<CashMachine> GetCashMachines();
        CashMachine GetCashMachine(int id);
        void CreateCashMachine(CashMachineCreateDto cashMachineDto);
        void InsertCash(OperationCellsDto operationDto, int id);
        void RetrieveCash(OperationCellsDto operationDto, int id);
        void DeleteCashMachine(int id);
    }
}
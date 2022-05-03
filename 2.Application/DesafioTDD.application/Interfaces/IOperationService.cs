using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Interfaces
{
    public interface IOperationService
    {
        List<Operation> GetOperations(int customerId);
        Operation GetOperation(int id);
        void OperationDeposit(OperationCellsDto operationDto, int cashMachineId, int userId);
        OperationWithdrawDto OperationWithdraw(decimal totalValue, int cashMachineId, int userId);
    }
}
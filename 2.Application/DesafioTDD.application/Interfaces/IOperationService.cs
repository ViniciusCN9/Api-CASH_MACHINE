using System.Collections.Generic;
using DesafioTDD.application.DataTransferObjects;

namespace DesafioTDD.application.Interfaces
{
    public interface IOperationService
    {
        List<object> GetOperations(int customerId);
        void OperationDeposit(CellsDto operationDto, int cashMachineId, int userId);
        OperationWithdrawDto OperationWithdraw(decimal totalValue, int cashMachineId, int userId);
    }
}
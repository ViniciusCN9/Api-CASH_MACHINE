using System.Collections.Generic;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.domain.Repositories
{
    public interface IOperationRepository
    {
        List<Operation> GetOperations(int customerId);
        Operation GetOperation(int id);
        void CreateOperation(Operation operation);
    }
}
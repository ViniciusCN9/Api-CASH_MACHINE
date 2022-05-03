using System.Collections.Generic;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.domain.Repositories
{
    public interface IManagerRepository
    {
        List<Manager> GetManagers();
        Manager GetManager(int id);
        Manager LoginManager(string username, string password);
    }
}
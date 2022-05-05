using System.Collections.Generic;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.domain.Repositories
{
    public interface IManagerRepository
    {
        Manager LoginManager(string username, string password);
    }
}
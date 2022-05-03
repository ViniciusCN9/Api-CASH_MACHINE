using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Interfaces
{
    public interface IManagerService
    {
        Manager LoginManager(string username, string password);
    }
}
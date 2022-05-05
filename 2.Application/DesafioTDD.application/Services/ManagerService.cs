using System;
using DesafioTDD.application.Interfaces;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;

namespace DesafioTDD.application.Services
{
    public class ManagerService : IManagerService
    {
        private IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public Manager LoginManager(string username, string password)
        {
            var manager = _managerRepository.LoginManager(username, password);
            if (manager is null)
                throw new ArgumentException("Credenciais incorretas");

            return manager;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;
using DesafioTDD.infra.Database.Context;

namespace DesafioTDD.infra.Database.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _context;
        
        public ManagerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Manager GetManager(int id)
        {
            Manager manager;
            try
            {
                manager = _context.Managers.FirstOrDefault(e => e.Id == id);
            }
            catch
            {
                manager = null;
            }

            return manager;
        }

        public List<Manager> GetManagers()
        {
            List<Manager> managers;
            try
            {
                managers = _context.Managers.ToList();
            }
            catch
            {
                managers = null;
            }

            return managers;
        }

        public Manager LoginManager(string username, string password)
        {
            Manager manager;
            try
            {
                manager = _context.Managers.FirstOrDefault(e => e.Username == username && e.Password == password);
            }
            catch
            {
                manager = null;
            }

            return manager;
        }
    }
}
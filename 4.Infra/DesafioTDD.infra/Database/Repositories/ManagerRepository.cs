using System.Linq;
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
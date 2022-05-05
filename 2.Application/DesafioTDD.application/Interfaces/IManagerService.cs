using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Interfaces
{
    public interface IManagerService
    {
        Manager LoginManager(string username, string password);
    }
}
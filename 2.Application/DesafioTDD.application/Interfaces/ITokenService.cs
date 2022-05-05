using DesafioTDD.domain.Entities.Base;

namespace DesafioTDD.application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.domain.Entities.Base;

namespace DesafioTDD.application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
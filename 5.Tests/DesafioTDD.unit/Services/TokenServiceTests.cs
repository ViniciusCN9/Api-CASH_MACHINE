using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.Interfaces;
using DesafioTDD.application.Services;
using DesafioTDD.domain.Entities.Base;
using DesafioTDD.domain.Enums;
using FluentAssertions;
using Xunit;

namespace DesafioTDD.unit.Services
{
    public class TokenServiceTests
    {
        private ITokenService _tokenService;

        public TokenServiceTests()
        {
            _tokenService = new TokenService();
        }

        [Fact(DisplayName = "Deve retornar token quando recebe um usuário")]
        [Trait("Method", "GenerateToken")]
        [Trait("Class", "TokenService")]
        [Trait("Namespace", "Services")]
        public void Deve_Retornar_Token_Quando_Recebe_Usuario()
        {
            var user = new User()
            {
                Password = "teste123",
                Role = ERole.CUSTOMER
            };

            var result = _tokenService.GenerateToken(user);

            result.Should().Contain(".", Exactly.Times(2));
        }

        [Fact(DisplayName = "Deve lançar exceção para erro ao gerar token")]
        [Trait("Method", "GenerateToken")]
        [Trait("Class", "TokenService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Erro_Ao_Gerar_Token()
        {
            User user = null;

            var exception = Assert.Throws<Exception>(() => _tokenService.GenerateToken(user));

            Assert.Equal("Erro ao gerar token", exception.Message);
        }
    }
}
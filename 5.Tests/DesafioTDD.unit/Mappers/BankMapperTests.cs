using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Mappers;
using DesafioTDD.domain.Entities;
using FluentAssertions;
using Xunit;

namespace DesafioTDD.unit.Mappers
{
    public class BankMapperTests
    {
        [Fact(DisplayName = "Deve retornar Bank quando recebe BankCreateDto")]
        [Trait("Method", "ToDomain")]
        [Trait("Class", "BankMapper")]
        [Trait("Namespace", "Mappers")]
        public void Deve_Retornar_Bank_Quando_Recebe_BankCreateDto()
        {
            var bankDto = new BankCreateDto()
            {
                Name = "teste123",
                CardNumberPrefix = "1234"
            };
            var expected = new Bank()
            {
                Name = "teste123",
                CardNumberPrefix = "1234"
            };

            var result = bankDto.ToDomain();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
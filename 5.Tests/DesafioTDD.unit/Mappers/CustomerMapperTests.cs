using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Mappers;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Enums;
using FluentAssertions;
using Xunit;

namespace DesafioTDD.unit.Mappers
{
    public class CustomerMapperTests
    {
        [Fact(DisplayName = "Deve retornar Bank Customer recebe CustomerRegisterDto")]
        [Trait("Method", "ToDomain")]
        [Trait("Class", "CustomerMapper")]
        [Trait("Namespace", "Mappers")]
        public void Deve_Retornar_Customer_Quando_Recebe_CustomerRegisterDto()
        {
            var customerDto = new CustomerRegisterDto()
            {
                Name = "teste123",
                Password = "teste123",
                BankId = 1
            };
            var expected = new Customer()
            {
                Name = "teste123",
                Password = "teste123",
                Balance = 0m,
                Role = ERole.CUSTOMER
            };

            var result = customerDto.ToDomain();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
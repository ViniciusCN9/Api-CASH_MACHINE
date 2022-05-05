using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Mappers;
using DesafioTDD.domain.Entities;
using FluentAssertions;
using Xunit;

namespace DesafioTDD.unit.Mappers
{
    public class CashMachineMappperTests
    {
        [Fact(DisplayName = "Deve retornar Bank CashMachine recebe CashMachineCreateDto")]
        [Trait("Method", "ToDomain")]
        [Trait("Class", "CashMachineMapper")]
        [Trait("Namespace", "Mappers")]
        public void Deve_Retornar_CashMachine_Quando_Recebe_CashMachineCreateDto()
        {
            var cashMachineDto = new CashMachineCreateDto()
            {
                BankId = 1
            };
            var expected = new CashMachine()
            {
                AmountOne = 0, AmountTwo = 0, AmountFive = 0, AmountTen  = 0, AmountTwenty = 0, AmountFifty = 0, AmountOneHundred = 0, AmountTwoHundred = 0,
                TotalValue = 0m
            };

            var result = cashMachineDto.ToDomain();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
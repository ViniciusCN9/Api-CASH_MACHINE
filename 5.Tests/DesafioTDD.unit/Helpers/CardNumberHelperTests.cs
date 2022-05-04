using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.Helpers;
using FluentAssertions;
using Xunit;

namespace DesafioTDD.unit.Helpers
{
    public class CardNumberHelperTests
    {
        private CardNumberHelper _cardNumberHelper;

        public CardNumberHelperTests()
        {
            _cardNumberHelper = new CardNumberHelper();
        }

        [Theory(DisplayName = "Deve retornar número do cartão quando recebe o prefixo")]
        [Trait("Method", "GenerateCardNumber")]
        [Trait("Class", "CardNumberHelper")]
        [Trait("Namespace", "Helpers")]
        [InlineData("1234-5678-9123")]
        [InlineData("1234")]
        public void Deve_Retornar_Numero_Cartao_Quando_Recebe_Prefixo(string prefix)
        {
            var expecteds = prefix.Split("-");

            var result = _cardNumberHelper.GenerateCardNumber(prefix);

            result.Should().ContainAny(expecteds);
        }

        [Fact(DisplayName = "Deve retornar quatro algarismos")]
        [Trait("Method", "GenerateFourRandom")]
        [Trait("Class", "CardNumberHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Retornar_Quatro_Algarismos()
        {
            var result = _cardNumberHelper.GenerateFourRandom();

            Assert.Equal(4, result.Length);
        }

        [Fact(DisplayName = "Deve retornar apenas números")]
        [Trait("Method", "GenerateFourRandom")]
        [Trait("Class", "CardNumberHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Retornar_Apenas_Numeros()
        {
            var result = _cardNumberHelper.GenerateFourRandom();

            Assert.Matches(@"^[\d]", result);
        }
    }
}
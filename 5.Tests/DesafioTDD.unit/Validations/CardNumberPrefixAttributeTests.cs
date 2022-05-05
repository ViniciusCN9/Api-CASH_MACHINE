using DesafioTDD.application.Validations;
using Xunit;

namespace DesafioTDD.unit.Validations
{
    public class CardNumberPrefixAttributeTests
    {
        private CardNumberPrefixAttribute _cardNumberPrefixAttribute;

        public CardNumberPrefixAttributeTests()
        {
            _cardNumberPrefixAttribute = new CardNumberPrefixAttribute();
        }

        [Theory(DisplayName = "Deve retornar sucesso quando recebe valor nulo ou vazio")]
        [Trait("Method", "IsValid")]
        [Trait("Class", "CardNumberPrefixAttribute")]
        [Trait("Namespace", "Validations")]
        [InlineData(null)]
        [InlineData("")]
        public void Deve_Retornar_Sucesso_Quando_Recebe_Valor_Nulo_Ou_Vazio(string value)
        {
            var result = _cardNumberPrefixAttribute.IsValid(value);

            Assert.True(result);
        }

        [Theory(DisplayName = "Deve retornar erro quando recebe valor não numérico")]
        [Trait("Method", "IsValid")]
        [Trait("Class", "CardNumberPrefixAttribute")]
        [Trait("Namespace", "Validations")]
        [InlineData("aeiou")]
        [InlineData("-*/+$")]
        public void Deve_Retornar_Erro_Quando_Recebe_Valor_Nao_Numerico(string value)
        {
            var result = _cardNumberPrefixAttribute.IsValid(value);

            Assert.False(result);
        }

        [Theory(DisplayName = "Deve retornar erro quando valor sem separadores não é múltiplo de quatro")]
        [Trait("Method", "IsValid")]
        [Trait("Class", "CardNumberPrefixAttribute")]
        [Trait("Namespace", "Validations")]
        [InlineData("1234-1234-1234-12")]
        [InlineData("1234-1234-1")]
        [InlineData("123")]
        public void Deve_Retornar_Erro_Quando_Valor_Sem_Separadores_Nao_Multiplo_De_Quatro(string value)
        {
            var result = _cardNumberPrefixAttribute.IsValid(value);

            Assert.False(result);
        }

        [Theory(DisplayName = "Deve retornar sucesso")]
        [Trait("Method", "IsValid")]
        [Trait("Class", "CardNumberPrefixAttribute")]
        [Trait("Namespace", "Validations")]
        [InlineData("1234-1234-1234-1234")]
        [InlineData("1234-1234-")]
        [InlineData("1234")]
        public void Deve_Retornar_Sucesso(string value)
        {
            var result = _cardNumberPrefixAttribute.IsValid(value);

            Assert.True(result);
        }
    }
}
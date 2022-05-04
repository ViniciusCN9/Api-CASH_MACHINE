using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Helpers;
using DesafioTDD.domain.Entities;
using FluentAssertions;
using Xunit;

namespace DesafioTDD.unit.Helpers
{
    public class OperationHelperTests
    {
        private OperationHelper _operationHelper;

        public OperationHelperTests()
        {
            _operationHelper = new OperationHelper();
        }

        [Fact(DisplayName = "Deve somar valores no caixa eletrônico")]
        [Trait("Method", "InsertCash")]
        [Trait("Class", "OperationHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Somar_Valores_Em_CashMachine()
        {
            var cashMachine = new CashMachine()
            {
                AmountOne = 0, AmountTwo = 0, AmountFive = 0, AmountTen = 0, AmountTwenty = 0, AmountFifty = 0, AmountOneHundred = 0, AmountTwoHundred = 0,
                TotalValue = 0m
            };
            var operationDto = new OperationCellsDto()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
            };
            var expected = new CashMachine()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
                TotalValue = 700m
            };

            _operationHelper.InsertCash(cashMachine, operationDto);

            cashMachine.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "Deve subtrair valores no caixa eletrônico")]
        [Trait("Method", "RetrieveCash")]
        [Trait("Class", "OperationHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Subtrair_Valores_Em_CashMachine()
        {
            var cashMachine = new CashMachine()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
                TotalValue = 700m
            };
            var operationDto = new OperationCellsDto()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
            };
            var expected = new CashMachine()
            {
                AmountOne = 0, AmountTwo = 0, AmountFive = 0, AmountTen = 0, AmountTwenty = 0, AmountFifty = 0, AmountOneHundred = 0, AmountTwoHundred = 0,
                TotalValue = 0m
            };

            _operationHelper.RetrieveCash(cashMachine, operationDto);

            cashMachine.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "Deve subtrair valores no caixa eletrônico")]
        [Trait("Method", "SumValue")]
        [Trait("Class", "OperationHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Retornar_Soma_das_Celulas_Quando_Recebe_OperationCellsDto()
        {
            var operationDto = new OperationCellsDto()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
            };
            var expected = 700m;

            var result = _operationHelper.SumValue(operationDto);

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Deve retornar OperationWithdrawDto enquanto subtrai valores no caixa eletrônico")]
        [Trait("Method", "ConvertToCells")]
        [Trait("Class", "OperationHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Retornar_OperationWithdrawDto_Enquanto_Subtrai_Valores_Em_CashMachine()
        {
            var totalValue = 700.99m;
            var cashMachine = new CashMachine()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
                TotalValue = 700m
            };
            var expected = new OperationWithdrawDto()
            {
                OperationDto = new OperationCellsDto()
                {
                    AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
                },
                WithdrawValue = 700m
            };

            var result = _operationHelper.ConvertToCells(cashMachine, totalValue);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "Deve retornar true quando valores estão disponíveis")]
        [Trait("Method", "CheckQuantity")]
        [Trait("Class", "OperationHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Retornar_True_Quando_Valores_Estao_Disponiveis()
        {
            var cashMachine = new CashMachine()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
                TotalValue = 700m
            };
            var operationDto = new OperationCellsDto()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
            };

            var result = _operationHelper.CheckQuantity(cashMachine, operationDto);

            Assert.True(result);
        }

        [Fact(DisplayName = "Deve retornar false quando valores não estão disponíveis")]
        [Trait("Method", "CheckQuantity")]
        [Trait("Class", "OperationHelper")]
        [Trait("Namespace", "Helpers")]
        public void Deve_Retornar_False_Quando_Valores_Nao_Estao_Disponiveis()
        {
            var cashMachine = new CashMachine()
            {
                AmountOne = 99, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
                TotalValue = 699m
            };
            var operationDto = new OperationCellsDto()
            {
                AmountOne = 100, AmountTwo = 50, AmountFive = 20, AmountTen = 10, AmountTwenty = 5, AmountFifty = 2, AmountOneHundred = 1, AmountTwoHundred = 0,
            };

            var result = _operationHelper.CheckQuantity(cashMachine, operationDto);

            Assert.False(result);
        }
    }
}
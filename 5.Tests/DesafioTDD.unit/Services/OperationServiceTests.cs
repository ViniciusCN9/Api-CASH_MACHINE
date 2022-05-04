using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.application.Helpers;
using DesafioTDD.application.Services;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace DesafioTDD.unit.Services
{
    public class OperationServiceTests
    {
        private OperationService _operationService;
        private Mock<IOperationRepository> _mockOperationRepository = new Mock<IOperationRepository>();
        private Mock<ICustomerRepository> _mockCustomerRepository = new Mock<ICustomerRepository>();
        private Mock<ICashMachineRepository> _mockCashMachineRepository = new Mock<ICashMachineRepository>();
        private Mock<OperationHelper> _mockOperationHelper = new Mock<OperationHelper>();

        [Fact(DisplayName = "Deve lançar exceção para incompatível em depósito")]
        [Trait("Method", "OperationDeposit")]
        [Trait("Class", "OperationService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Incompativel_Em_Deposito()
        {
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(new CashMachine(){ Bank = new Bank(){ Id = 1 } });
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(new Customer(){ Bank = new Bank(){ Id = 2 } });
            _operationService = new OperationService(_mockOperationRepository.Object, _mockCustomerRepository.Object, _mockCashMachineRepository.Object, _mockOperationHelper.Object);

            var exception = Assert.Throws<Exception>(() => _operationService.OperationDeposit(new OperationCellsDto(), It.IsAny<int>(), It.IsAny<int>()));

            Assert.Equal("Caixa eletrônico incompatível com banco do cliente", exception.Message);
        }

        [Fact(DisplayName = "Deve chamar CreateOperation em depósito")]
        [Trait("Method", "OperationDeposit")]
        [Trait("Class", "OperationService")]
        [Trait("Namespace", "Services")]
        public void Deve_Chamar_CreateOperation_Em_Deposito()
        {
            var cashMachine = new CashMachine()
            {
                Bank = new Bank(){ Id = 1 },
                AmountOne = 0, AmountTwo = 0, AmountFive = 0, AmountTen = 0, AmountTwenty = 0, AmountFifty = 0, AmountOneHundred = 0, AmountTwoHundred = 0,
                TotalValue = 0m
            };
            var operationDto = new OperationCellsDto()
            { 
                AmountOne = 0, AmountTwo = 0, AmountFive = 0, AmountTen = 0, AmountTwenty = 0, AmountFifty = 0, AmountOneHundred = 0, AmountTwoHundred = 0
            };
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(cashMachine);
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(new Customer(){ Bank = new Bank(){ Id = 1 } });
            _operationService = new OperationService(_mockOperationRepository.Object, _mockCustomerRepository.Object, _mockCashMachineRepository.Object, _mockOperationHelper.Object);

            _operationService.OperationDeposit(operationDto, It.IsAny<int>(), It.IsAny<int>());

            _mockOperationRepository.Verify(e => e.CreateOperation(It.IsAny<Operation>()), Times.Once);
        }

        [Fact(DisplayName = "Deve lançar exceção para incompatível em saque")]
        [Trait("Method", "OperationWithdraw")]
        [Trait("Class", "OperationService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Incompativel_Em_Saque()
        {
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(new CashMachine(){ Bank = new Bank(){ Id = 1 } });
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(new Customer(){ Bank = new Bank(){ Id = 2 } });
            _operationService = new OperationService(_mockOperationRepository.Object, _mockCustomerRepository.Object, _mockCashMachineRepository.Object, _mockOperationHelper.Object);

            var exception = Assert.Throws<Exception>(() => _operationService.OperationDeposit(new OperationCellsDto(), It.IsAny<int>(), It.IsAny<int>()));

            Assert.Equal("Caixa eletrônico incompatível com banco do cliente", exception.Message);
        }

        [Fact(DisplayName = "Deve lançar exceção para saldo insuficiente")]
        [Trait("Method", "OperationWithdraw")]
        [Trait("Class", "OperationService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Saldo_Insuficiente()
        {
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(new CashMachine(){ Bank = new Bank(){ Id = 1 } });
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(new Customer(){ Balance = 99.99m, Bank = new Bank(){ Id = 1 } });
            _operationService = new OperationService(_mockOperationRepository.Object, _mockCustomerRepository.Object, _mockCashMachineRepository.Object, _mockOperationHelper.Object);

            var exception = Assert.Throws<Exception>(() => _operationService.OperationWithdraw(100m, It.IsAny<int>(), It.IsAny<int>()));

            Assert.Equal("Saldo insuficiente", exception.Message);
        }

        [Fact(DisplayName = "Deve lançar exceção para valor indisponível")]
        [Trait("Method", "OperationWithdraw")]
        [Trait("Class", "OperationService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Valor_Indisponivel()
        {
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(new CashMachine(){ AmountOneHundred = 1, TotalValue = 100m, Bank = new Bank(){ Id = 1 } });
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(new Customer(){ Balance = 100.01m, Bank = new Bank(){ Id = 1 } });
            _operationService = new OperationService(_mockOperationRepository.Object, _mockCustomerRepository.Object, _mockCashMachineRepository.Object, _mockOperationHelper.Object);

            var exception = Assert.Throws<Exception>(() => _operationService.OperationWithdraw(100.01m, It.IsAny<int>(), It.IsAny<int>()));

            Assert.Equal("Valor indisponível no caixa eletrônico", exception.Message);
        }

        [Fact(DisplayName = "Deve retornar OperationWithdrawDto")]
        [Trait("Method", "OperationWithdraw")]
        [Trait("Class", "OperationService")]
        [Trait("Namespace", "Services")]
        public void Deve_Retornar_OperationWithdrawDto()
        {
            var expected = new OperationWithdrawDto()
            {
                OperationDto = new OperationCellsDto(){ AmountOneHundred = 1 },
                WithdrawValue = 100m
            };
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(new CashMachine(){ AmountOneHundred = 1, TotalValue = 100m, Bank = new Bank(){ Id = 1 } });
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(new Customer(){ Balance = 100m, Bank = new Bank(){ Id = 1 } });
            _operationService = new OperationService(_mockOperationRepository.Object, _mockCustomerRepository.Object, _mockCashMachineRepository.Object, _mockOperationHelper.Object);

            var result = _operationService.OperationWithdraw(100m, It.IsAny<int>(), It.IsAny<int>());

            result.Should().BeEquivalentTo(expected);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.Helpers;
using DesafioTDD.application.Services;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;
using Moq;
using Xunit;

namespace DesafioTDD.unit.Services
{
    public class CashMachineServiceTests
    {
        private CashMachineService _cashMachineService;
        private Mock<ICashMachineRepository> _mockCashMachineRepository = new Mock<ICashMachineRepository>();
        private Mock<IBankRepository> _mockBankRepository = new Mock<IBankRepository>();
        private Mock<OperationHelper> _mockOperationHelper = new Mock<OperationHelper>();

        [Fact(DisplayName = "Deve lançar exceção para caixa eletrônico com dinheiro")]
        [Trait("Method", "DeleteCashMachine")]
        [Trait("Class", "CashMachineService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Caixa_Eletronico_Com_Dinheiro()
        {
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(new CashMachine(){ TotalValue = 100m });
            _cashMachineService = new CashMachineService(_mockCashMachineRepository.Object, _mockBankRepository.Object,  _mockOperationHelper.Object);

            var exception = Assert.Throws<Exception>(() => _cashMachineService.DeleteCashMachine(It.IsAny<int>()));

            Assert.Equal("Não é possível deletar um caixa eletrônico com dinheiro", exception.Message);
        }

        [Fact(DisplayName = "Deve chamar DeleteCashMachine")]
        [Trait("Method", "DeleteCashMachine")]
        [Trait("Class", "CashMachineService")]
        [Trait("Namespace", "Services")]
        public void Deve_Chamar_DeleteCashMachine()
        {
            var cashMachine = new CashMachine(){ TotalValue = 0m };
            _mockCashMachineRepository.Setup(e => e.GetCashMachine(It.IsAny<int>())).Returns(cashMachine);
            _cashMachineService = new CashMachineService(_mockCashMachineRepository.Object, _mockBankRepository.Object,  _mockOperationHelper.Object);

            _cashMachineService.DeleteCashMachine(It.IsAny<int>());

            _mockCashMachineRepository.Verify(e => e.DeleteCashMachine(cashMachine), Times.Once);
        }
    }
}
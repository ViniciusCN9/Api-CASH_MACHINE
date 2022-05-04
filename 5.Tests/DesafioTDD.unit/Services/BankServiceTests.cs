using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.Services;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Repositories;
using DesafioTDD.unit.FakeRepositories;
using Moq;
using Xunit;

namespace DesafioTDD.unit.Services
{
    public class BankServiceTests
    {
        private BankService _bankService;
        private IBankRepository _fakeBankRepository = new FakeBankRepository();
        private Mock<IBankRepository> _mockBankRepository = new Mock<IBankRepository>();
        private Mock<ICashMachineRepository> _mockCashMachineRepository = new Mock<ICashMachineRepository>();
        private Mock<ICustomerRepository> _mockCustomerRepository = new Mock<ICustomerRepository>();

        [Fact(DisplayName = "Deve lançar exceção para caixas eletrônicos cadastrados")]
        [Trait("Method", "DeleteBank")]
        [Trait("Class", "BankService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Caixas_Eletronicos_Cadastrados()
        {
            _mockBankRepository.Setup(e => e.GetBank(It.IsAny<int>())).Returns(new Bank(){ Id = 1 });
            _mockCashMachineRepository.Setup(e => e.GetCashMachines()).Returns(new List<CashMachine>(){ new CashMachine(){ Bank = new Bank(){ Id = 1 } } });
            _bankService = new BankService(_mockBankRepository.Object, _mockCashMachineRepository.Object, _mockCustomerRepository.Object);

            var exception = Assert.Throws<Exception>(() => _bankService.DeleteBank(1));

            Assert.Equal("Não é possível deletar um banco com caixas eletrônicos cadastrados", exception.Message);
        }

        [Fact(DisplayName = "Deve lançar exceção para clientes cadastrados")]
        [Trait("Method", "DeleteBank")]
        [Trait("Class", "BankService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Clientes_Cadastrados()
        {
            _mockBankRepository.Setup(e => e.GetBank(It.IsAny<int>())).Returns(new Bank(){ Id = 1 });
            _mockCashMachineRepository.Setup(e => e.GetCashMachines()).Returns(new List<CashMachine>(){ new CashMachine(){ Bank = new Bank(){ Id = 2 } } });
            _mockCustomerRepository.Setup(e => e.GetCustomers()).Returns(new List<Customer>(){ new Customer(){ Bank = new Bank() { Id = 1} } });
            _bankService = new BankService(_mockBankRepository.Object, _mockCashMachineRepository.Object, _mockCustomerRepository.Object);

            var exception = Assert.Throws<Exception>(() => _bankService.DeleteBank(1));

            Assert.Equal("Não é possível deletar um banco com clientes cadastrados", exception.Message);
        }

        [Fact(DisplayName = "Deve chamar DeleteBank")]
        [Trait("Method", "DeleteBank")]
        [Trait("Class", "BankService")]
        [Trait("Namespace", "Services")]
        public void Deve_Chamar_DeleteBank()
        {
            var bank = new Bank(){ Id = 1 };
            _mockBankRepository.Setup(e => e.GetBank(It.IsAny<int>())).Returns(bank);
            _mockCashMachineRepository.Setup(e => e.GetCashMachines()).Returns(new List<CashMachine>(){ new CashMachine(){ Bank = new Bank(){ Id = 2 } } });
            _mockCustomerRepository.Setup(e => e.GetCustomers()).Returns(new List<Customer>(){ new Customer(){ Bank = new Bank() { Id = 2} } });
            _bankService = new BankService(_mockBankRepository.Object, _mockCashMachineRepository.Object, _mockCustomerRepository.Object);

            _bankService.DeleteBank(1);

            _mockBankRepository.Verify(e => e.DeleteBank(bank), Times.Once);
        }

        [Theory(DisplayName = "Deve retornar true quando recebe CardNumberPrefix nulo ou vazio")]
        [Trait("Method", "VerifyPrefix")]
        [Trait("Class", "BankService")]
        [Trait("Namespace", "Services")]
        [InlineData(null)]
        [InlineData("")]
        public void Deve_Retornar_True_Quando_Recebe_CardNumberPrefix_Nulo_Ou_Vazio(string cardNumberPrefix)
        {
            _bankService = new BankService(_mockBankRepository.Object, _mockCashMachineRepository.Object, _mockCustomerRepository.Object);

            var result = _bankService.VerifyPrefixes(cardNumberPrefix);

            Assert.True(result);
        }

        [Fact(DisplayName = "Deve retornar false quando encontra prefixos existentes")]
        [Trait("Method", "VerifyPrefix")]
        [Trait("Class", "BankService")]
        [Trait("Namespace", "Services")]
        public void Deve_Retornar_False_Quando_Encontra_Prefixos_Existentes()
        {
            var cardNumberPrefix = "0000-1234-0000";  
            _bankService = new BankService(_fakeBankRepository, _mockCashMachineRepository.Object, _mockCustomerRepository.Object);

            var result = _bankService.VerifyPrefixes(cardNumberPrefix);

            Assert.False(result);
        }

        [Fact(DisplayName = "Deve retornar true quando não encontra prefixos existentes")]
        [Trait("Method", "VerifyPrefix")]
        [Trait("Class", "BankService")]
        [Trait("Namespace", "Services")]
        public void Deve_Retornar_True_Quando_Nao_Encontra_Prefixos_Existentes()
        {
            var cardNumberPrefix = "0000-5678-0000";  
            _bankService = new BankService(_fakeBankRepository, _mockCashMachineRepository.Object, _mockCustomerRepository.Object);

            var result = _bankService.VerifyPrefixes(cardNumberPrefix);

            Assert.True(result);
        }
    }
}
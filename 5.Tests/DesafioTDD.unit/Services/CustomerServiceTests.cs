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
    public class CustomerServiceTests
    {
        private CustomerService _customerService;
        private Mock<ICustomerRepository> _mockCustomerRepository = new Mock<ICustomerRepository>();
        private Mock<IBankRepository> _mockBankRepository = new Mock<IBankRepository>();
        private Mock<CardNumberHelper> _mockCardNumberHelper = new Mock<CardNumberHelper>();

        [Fact(DisplayName = "Deve lançar exceção para cliente com saldo")]
        [Trait("Method", "DeleteCustomer")]
        [Trait("Class", "CustomerService")]
        [Trait("Namespace", "Services")]
        public void Deve_Lancar_Excecao_Para_Cliente_Com_Saldo()
        {
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(new Customer(){ Balance = 100m });
            _customerService = new CustomerService(_mockCustomerRepository.Object, _mockBankRepository.Object, _mockCardNumberHelper.Object);

            var exception = Assert.Throws<Exception>(() => _customerService.DeleteCustomer(It.IsAny<int>()));

            Assert.Equal("Não é possível deletar um cliente com saldo", exception.Message);
        }

        [Fact(DisplayName = "Deve chamar DeleteCustomer")]
        [Trait("Method", "DeleteCustomer")]
        [Trait("Class", "CustomerService")]
        [Trait("Namespace", "Services")]
        public void Deve_Chamar_DeleteCustomer()
        {
            var customer = new Customer(){ Balance = 0m };
            _mockCustomerRepository.Setup(e => e.GetCustomer(It.IsAny<int>())).Returns(customer);
            _customerService = new CustomerService(_mockCustomerRepository.Object, _mockBankRepository.Object, _mockCardNumberHelper.Object);

            _customerService.DeleteCustomer(It.IsAny<int>());

            _mockCustomerRepository.Verify(e => e.DeleteCustomer(customer), Times.Once);
        }
    }
}
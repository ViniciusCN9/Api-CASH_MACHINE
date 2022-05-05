using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;
using DesafioTDD.domain.Enums;

namespace DesafioTDD.application.Mappers
{
    public static class CustomerMapper
    {
        public static Customer ToDomain(this CustomerRegisterDto customerDto) => new Customer
        {
            Name = customerDto.Name,
            Password = customerDto.Password.ToString(),
            Balance = 0m,
            Role = ERole.CUSTOMER
        };
    }
}
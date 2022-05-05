using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Mappers
{
    public static class BankMapper
    {
        public static Bank ToDomain(this BankCreateDto bankDto) => new Bank
        {
            Name = bankDto.Name,
            CardNumberPrefix = bankDto.CardNumberPrefix
        };
    }
}
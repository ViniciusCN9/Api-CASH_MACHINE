using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Password = customerDto.Password,
            Balance = 0m,
            Role = ERole.CUSTOMER
        };
    }
}
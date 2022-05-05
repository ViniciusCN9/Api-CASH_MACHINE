using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Mappers
{
    public static class CashMachineMapper
    {
        public static CashMachine ToDomain(this CashMachineCreateDto cashMachineDto) => new CashMachine
        {
            AmountOne = 0,
            AmountTwo = 0,
            AmountFive = 0,
            AmountTen  = 0,
            AmountTwenty = 0,
            AmountFifty = 0,
            AmountOneHundred = 0,
            AmountTwoHundred = 0,
            TotalValue = 0m
        };
    }
}
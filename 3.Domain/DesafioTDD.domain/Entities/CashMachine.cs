using DesafioTDD.domain.Entities.Base;

namespace DesafioTDD.domain.Entities
{
    public class CashMachine : Entity
    {
        public Bank Bank { get; set; }
        public int AmountOne { get; set; }
        public int AmountTwo { get; set; }
        public int AmountFive { get; set; }
        public int AmountTen { get; set; }
        public int AmountTwenty { get; set; }
        public int AmountFifty { get; set; }
        public int AmountOneHundred { get; set; }
        public int AmountTwoHundred { get; set; }
        public decimal TotalValue { get; set; }
    }
}
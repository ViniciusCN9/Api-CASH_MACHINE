using System;
using DesafioTDD.domain.Entities.Base;

namespace DesafioTDD.domain.Entities
{
    public class Operation : Entity
    {
        public Customer Customer { get; set; }
        public CashMachine CashMachine { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Date { get; set; }
    }
}
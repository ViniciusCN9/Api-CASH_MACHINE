using DesafioTDD.domain.Entities.Base;

namespace DesafioTDD.domain.Entities
{
    public class Customer : User
    {
        public string Name { get; set; }
        public Bank Bank { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
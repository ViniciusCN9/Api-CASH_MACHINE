using DesafioTDD.domain.Entities.Base;

namespace DesafioTDD.domain.Entities
{
    public class Bank : Entity
    {
        public string Name { get; set; }
        public string CardNumberPrefix { get; set; }  
    }
}
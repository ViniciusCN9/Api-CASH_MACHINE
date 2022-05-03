using DesafioTDD.domain.Enums;

namespace DesafioTDD.domain.Entities.Base
{
    public class User : Entity
    {
        public string Password { get; set; }
        public ERole Role { get; set; }
    }
}
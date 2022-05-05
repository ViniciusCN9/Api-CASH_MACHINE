using System.ComponentModel.DataAnnotations;

namespace DesafioTDD.application.DataTransferObjects
{
    public class ManagerLoginDto
    {
        [Required(ErrorMessage = "Informe o usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}
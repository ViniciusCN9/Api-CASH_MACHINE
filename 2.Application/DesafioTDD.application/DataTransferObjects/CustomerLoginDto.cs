using System.ComponentModel.DataAnnotations;

namespace DesafioTDD.application.DataTransferObjects
{
    public class CustomerLoginDto
    {
        [Required(ErrorMessage = "Informe o número do cartão")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace DesafioTDD.application.DataTransferObjects
{
    public class CustomerUpdateDto
    {
        [StringLength(100, ErrorMessage = "Nome do cliente deve ter no mínimo {2} e no máximo {1} caracter(es)", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "Senha deve ter 6 dígitos")]
        public string Password { get; set; }
    }
}
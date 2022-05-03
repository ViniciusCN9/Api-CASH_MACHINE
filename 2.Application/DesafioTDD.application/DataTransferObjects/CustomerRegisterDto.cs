using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTDD.application.DataTransferObjects
{
    public class CustomerRegisterDto
    {
        [Required(ErrorMessage = "Insira o nome do cliente")]
        [StringLength(100, ErrorMessage = "Nome do cliente deve ter no mínimo {2} e no máximo {1} caracter(es)", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insira a senha do cliente")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Senha deve ter 6 dígitos")]
        public string Password { get; set; }

        [Required]
        public int BankId { get; set; }
    }
}
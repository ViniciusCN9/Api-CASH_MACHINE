using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTDD.application.DataTransferObjects
{
    public class CustomerLoginDto
    {
        [Required(ErrorMessage = "Informe o número do cartão")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Senha deve ter 6 dígitos")]
        public string Password { get; set; }
    }
}
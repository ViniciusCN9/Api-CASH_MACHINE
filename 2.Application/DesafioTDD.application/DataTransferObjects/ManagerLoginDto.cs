using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTDD.application.DataTransferObjects
{
    public class ManagerLoginDto
    {
        [Required(ErrorMessage = "Informe o usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Senha deve ter 6 dígitos")]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.Validations;

namespace DesafioTDD.application.DataTransferObjects
{
    public class BankCreateDto
    {
        [Required(ErrorMessage = "Insira o nome do banco")]
        [StringLength(30, ErrorMessage = "Nome do banco deve ter no mínimo {2} e no máximo {1} caracter(es)", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insira o prefixo do número do cartão")]
        [CardNumberPrefix]
        public string CardNumberPrefix { get; set; }
    }
}
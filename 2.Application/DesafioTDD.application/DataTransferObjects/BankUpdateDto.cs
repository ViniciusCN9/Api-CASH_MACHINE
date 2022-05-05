using System.ComponentModel.DataAnnotations;
using DesafioTDD.application.Validations;

namespace DesafioTDD.application.DataTransferObjects
{
    public class BankUpdateDto
    {
        [StringLength(30, ErrorMessage = "Nome do banco deve ter no mínimo {2} e no máximo {1} caracter(es)", MinimumLength = 2)]
        public string Name { get; set; }

        [CardNumberPrefix]
        public string CardNumberPrefix { get; set; }
    }
}
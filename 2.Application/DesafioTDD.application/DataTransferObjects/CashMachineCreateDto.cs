using System.ComponentModel.DataAnnotations;

namespace DesafioTDD.application.DataTransferObjects
{
    public class CashMachineCreateDto
    {
        [Required(ErrorMessage = "Informe o banco")]
        public int BankId { get; set; }
    }
}
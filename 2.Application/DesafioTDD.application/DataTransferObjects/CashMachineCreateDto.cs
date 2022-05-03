using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTDD.application.DataTransferObjects
{
    public class CashMachineCreateDto
    {
        [Required(ErrorMessage = "Informe o banco")]
        public int BankId { get; set; }
    }
}
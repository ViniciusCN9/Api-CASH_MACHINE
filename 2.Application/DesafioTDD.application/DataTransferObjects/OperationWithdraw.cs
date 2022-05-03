using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTDD.application.DataTransferObjects
{
    public class OperationWithdrawDto
    {
        public OperationCellsDto OperationDto { get; set; }
        public decimal WithdrawValue { get; set; }
    }
}
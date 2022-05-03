using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTDD.application.DataTransferObjects
{
    public class OperationCellsDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountOne { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountTwo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountFive { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountTen { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountTwenty { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountFifty { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountOneHundred { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int AmountTwoHundred { get; set; }
    }
}
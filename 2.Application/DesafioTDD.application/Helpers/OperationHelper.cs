using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Helpers
{
    public class OperationHelper
    {
        public void InsertCash(CashMachine cashMachine, OperationCellsDto operationDto)
        {
            cashMachine.AmountOne += operationDto.AmountOne;
            cashMachine.TotalValue += (1m * operationDto.AmountOne);

            cashMachine.AmountTwo += operationDto.AmountTwo;
            cashMachine.TotalValue += (2m * operationDto.AmountTwo);

            cashMachine.AmountFive += operationDto.AmountFive;
            cashMachine.TotalValue += (5m * operationDto.AmountFive);
            
            cashMachine.AmountTen += operationDto.AmountTen;
            cashMachine.TotalValue += (10m * operationDto.AmountTen);

            cashMachine.AmountTwenty += operationDto.AmountTwenty;
            cashMachine.TotalValue += (20m * operationDto.AmountTwenty);

            cashMachine.AmountFifty += operationDto.AmountFifty;
            cashMachine.TotalValue += (50m * operationDto.AmountFifty);

            cashMachine.AmountOneHundred += operationDto.AmountOneHundred;
            cashMachine.TotalValue += (100m * operationDto.AmountOneHundred);

            cashMachine.AmountTwoHundred += operationDto.AmountTwoHundred;
            cashMachine.TotalValue += (200m * operationDto.AmountTwoHundred);

            return;
        }

        public void RetrieveCash(CashMachine cashMachine, OperationCellsDto operationDto)
        {
            cashMachine.AmountOne -= operationDto.AmountOne;
            cashMachine.TotalValue -= (1m * operationDto.AmountOne);

            cashMachine.AmountTwo -= operationDto.AmountTwo;
            cashMachine.TotalValue -= (2m * operationDto.AmountTwo);

            cashMachine.AmountFive -= operationDto.AmountFive;
            cashMachine.TotalValue -= (5m * operationDto.AmountFive);

            cashMachine.AmountTen -= operationDto.AmountTen;
            cashMachine.TotalValue -= (10m * operationDto.AmountTen);

            cashMachine.AmountTwenty -= operationDto.AmountTwenty;
            cashMachine.TotalValue -= (20m * operationDto.AmountTwenty);

            cashMachine.AmountFifty -= operationDto.AmountFifty;
            cashMachine.TotalValue -= (50m * operationDto.AmountFifty);

            cashMachine.AmountOneHundred -= operationDto.AmountOneHundred;
            cashMachine.TotalValue -= (100m * operationDto.AmountOneHundred);

            cashMachine.AmountTwoHundred -= operationDto.AmountTwoHundred;
            cashMachine.TotalValue -= (200m * operationDto.AmountTwoHundred);

            return;
        }

        public decimal SumValue(OperationCellsDto operationDto)
        {
            decimal total = 0;

            total += (1m * operationDto.AmountOne);
            total += (2m * operationDto.AmountTwo);
            total += (5m * operationDto.AmountFive);
            total += (10m * operationDto.AmountTen);
            total += (20m * operationDto.AmountTwenty);
            total += (50m * operationDto.AmountFifty);
            total += (100m * operationDto.AmountOneHundred);
            total += (200m * operationDto.AmountTwoHundred);

            return total;
        }

        public OperationWithdrawDto ConvertToCells(CashMachine cashMachine, decimal totalValue)
        {
            var operationDto = new OperationCellsDto()
            {
                AmountOne = 0,
                AmountTwo = 0,
                AmountFive = 0,
                AmountTen = 0,
                AmountTwenty = 0,
                AmountFifty = 0,
                AmountOneHundred = 0,
                AmountTwoHundred = 0
            };

            var value = totalValue;
            while (value >= 200m && cashMachine.AmountTwoHundred > 0)
            {
                operationDto.AmountTwoHundred ++;
                cashMachine.AmountTwoHundred --;
                cashMachine.TotalValue -= 200m;
                value -= 200m;
            }

            while (value >= 100m && cashMachine.AmountOneHundred > 0)
            {
                operationDto.AmountOneHundred ++;
                cashMachine.AmountOneHundred --;
                cashMachine.TotalValue -= 100m;
                value -= 100m;
            }

            while (value >= 50m && cashMachine.AmountFifty > 0)
            {
                operationDto.AmountFifty ++;
                cashMachine.AmountFifty --;
                cashMachine.TotalValue -= 50m;
                value -= 50m;
            }

            while (value >= 20m && cashMachine.AmountTwenty > 0)
            {
                operationDto.AmountTwenty ++;
                cashMachine.AmountTwenty --;
                cashMachine.TotalValue -= 20m;
                value -= 20m;
            }

            while (value >= 10m && cashMachine.AmountTen > 0)
            {
                operationDto.AmountTen ++;
                cashMachine.AmountTen --;
                cashMachine.TotalValue -= 10m;
                value -= 10m;
            }

            while (value >= 5m && cashMachine.AmountFive > 0)
            {
                operationDto.AmountFive ++;
                cashMachine.AmountFive --;
                cashMachine.TotalValue -= 5m;
                value -= 5m;
            }

            while (value >= 2m && cashMachine.AmountTwo > 0)
            {
                operationDto.AmountTwo ++;
                cashMachine.AmountTwo --;
                cashMachine.TotalValue -= 2m;
                value -= 2m;
            }

            while (value >= 1m && cashMachine.AmountOne > 0)
            {
                operationDto.AmountOne ++;
                cashMachine.AmountOne --;
                cashMachine.TotalValue -= 1m;
                value -= 1m;
            }

            var operationWithdrawDto = new OperationWithdrawDto()
            {
                OperationDto = operationDto,
                WithdrawValue = totalValue - value
            };

            return operationWithdrawDto;
        }

        public bool CheckQuantity(CashMachine cashMachine, OperationCellsDto operationDto)
        {
            if
            (
                cashMachine.AmountOne >= operationDto.AmountOne &&
                cashMachine.AmountTwo >= operationDto.AmountTwo &&
                cashMachine.AmountFive >= operationDto.AmountFive &&
                cashMachine.AmountTen >= operationDto.AmountTen &&
                cashMachine.AmountTwenty >= operationDto.AmountTwenty &&
                cashMachine.AmountFifty >= operationDto.AmountFifty &&
                cashMachine.AmountOneHundred >= operationDto.AmountOneHundred &&
                cashMachine.AmountTwoHundred >= operationDto.AmountTwoHundred
            )
                return true;
            return false;
        }
    }
}
using DesafioTDD.application.DataTransferObjects;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Helpers
{
    public class OperationHelper
    {
        public void InsertCash(CashMachine cashMachine, CellsDto cellsDto)
        {
            cashMachine.AmountOne += cellsDto.AmountOne;
            cashMachine.TotalValue += (1m * cellsDto.AmountOne);

            cashMachine.AmountTwo += cellsDto.AmountTwo;
            cashMachine.TotalValue += (2m * cellsDto.AmountTwo);

            cashMachine.AmountFive += cellsDto.AmountFive;
            cashMachine.TotalValue += (5m * cellsDto.AmountFive);
            
            cashMachine.AmountTen += cellsDto.AmountTen;
            cashMachine.TotalValue += (10m * cellsDto.AmountTen);

            cashMachine.AmountTwenty += cellsDto.AmountTwenty;
            cashMachine.TotalValue += (20m * cellsDto.AmountTwenty);

            cashMachine.AmountFifty += cellsDto.AmountFifty;
            cashMachine.TotalValue += (50m * cellsDto.AmountFifty);

            cashMachine.AmountOneHundred += cellsDto.AmountOneHundred;
            cashMachine.TotalValue += (100m * cellsDto.AmountOneHundred);

            cashMachine.AmountTwoHundred += cellsDto.AmountTwoHundred;
            cashMachine.TotalValue += (200m * cellsDto.AmountTwoHundred);

            return;
        }

        public void RetrieveCash(CashMachine cashMachine, CellsDto cellsDto)
        {
            cashMachine.AmountOne -= cellsDto.AmountOne;
            cashMachine.TotalValue -= (1m * cellsDto.AmountOne);

            cashMachine.AmountTwo -= cellsDto.AmountTwo;
            cashMachine.TotalValue -= (2m * cellsDto.AmountTwo);

            cashMachine.AmountFive -= cellsDto.AmountFive;
            cashMachine.TotalValue -= (5m * cellsDto.AmountFive);

            cashMachine.AmountTen -= cellsDto.AmountTen;
            cashMachine.TotalValue -= (10m * cellsDto.AmountTen);

            cashMachine.AmountTwenty -= cellsDto.AmountTwenty;
            cashMachine.TotalValue -= (20m * cellsDto.AmountTwenty);

            cashMachine.AmountFifty -= cellsDto.AmountFifty;
            cashMachine.TotalValue -= (50m * cellsDto.AmountFifty);

            cashMachine.AmountOneHundred -= cellsDto.AmountOneHundred;
            cashMachine.TotalValue -= (100m * cellsDto.AmountOneHundred);

            cashMachine.AmountTwoHundred -= cellsDto.AmountTwoHundred;
            cashMachine.TotalValue -= (200m * cellsDto.AmountTwoHundred);

            return;
        }

        public decimal SumValue(CellsDto cellsDto)
        {
            decimal total = 0;

            total += (1m * cellsDto.AmountOne);
            total += (2m * cellsDto.AmountTwo);
            total += (5m * cellsDto.AmountFive);
            total += (10m * cellsDto.AmountTen);
            total += (20m * cellsDto.AmountTwenty);
            total += (50m * cellsDto.AmountFifty);
            total += (100m * cellsDto.AmountOneHundred);
            total += (200m * cellsDto.AmountTwoHundred);

            return total;
        }

        public OperationWithdrawDto ConvertToCells(CashMachine cashMachine, decimal totalValue)
        {
            var cellsDto = new CellsDto()
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
                cellsDto.AmountTwoHundred ++;
                cashMachine.AmountTwoHundred --;
                cashMachine.TotalValue -= 200m;
                value -= 200m;
            }

            while (value >= 100m && cashMachine.AmountOneHundred > 0)
            {
                cellsDto.AmountOneHundred ++;
                cashMachine.AmountOneHundred --;
                cashMachine.TotalValue -= 100m;
                value -= 100m;
            }

            while (value >= 50m && cashMachine.AmountFifty > 0)
            {
                cellsDto.AmountFifty ++;
                cashMachine.AmountFifty --;
                cashMachine.TotalValue -= 50m;
                value -= 50m;
            }

            while (value >= 20m && cashMachine.AmountTwenty > 0)
            {
                cellsDto.AmountTwenty ++;
                cashMachine.AmountTwenty --;
                cashMachine.TotalValue -= 20m;
                value -= 20m;
            }

            while (value >= 10m && cashMachine.AmountTen > 0)
            {
                cellsDto.AmountTen ++;
                cashMachine.AmountTen --;
                cashMachine.TotalValue -= 10m;
                value -= 10m;
            }

            while (value >= 5m && cashMachine.AmountFive > 0)
            {
                cellsDto.AmountFive ++;
                cashMachine.AmountFive --;
                cashMachine.TotalValue -= 5m;
                value -= 5m;
            }

            while (value >= 2m && cashMachine.AmountTwo > 0)
            {
                cellsDto.AmountTwo ++;
                cashMachine.AmountTwo --;
                cashMachine.TotalValue -= 2m;
                value -= 2m;
            }

            while (value >= 1m && cashMachine.AmountOne > 0)
            {
                cellsDto.AmountOne ++;
                cashMachine.AmountOne --;
                cashMachine.TotalValue -= 1m;
                value -= 1m;
            }

            var operationWithdrawDto = new OperationWithdrawDto()
            {
                CellsDto = cellsDto,
                WithdrawValue = totalValue - value
            };

            return operationWithdrawDto;
        }

        public bool CheckQuantity(CashMachine cashMachine, CellsDto cellsDto)
        {
            if
            (
                cashMachine.AmountOne >= cellsDto.AmountOne &&
                cashMachine.AmountTwo >= cellsDto.AmountTwo &&
                cashMachine.AmountFive >= cellsDto.AmountFive &&
                cashMachine.AmountTen >= cellsDto.AmountTen &&
                cashMachine.AmountTwenty >= cellsDto.AmountTwenty &&
                cashMachine.AmountFifty >= cellsDto.AmountFifty &&
                cashMachine.AmountOneHundred >= cellsDto.AmountOneHundred &&
                cashMachine.AmountTwoHundred >= cellsDto.AmountTwoHundred
            )
                return true;
            return false;
        }
    }
}
namespace DesafioTDD.application.DataTransferObjects
{
    public class OperationWithdrawDto
    {
        public CellsDto CellsDto { get; set; }
        public decimal WithdrawValue { get; set; }
    }
}
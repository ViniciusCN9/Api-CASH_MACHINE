using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioTDD.infra.Migrations
{
    public partial class SeedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Username", "Password", "Role" },
                values: new object[] { 1, "admin", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "CardNumberPrefix" },
                values: new object[] { 1, "TESTE", "0000" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "CardNumberPrefix" },
                values: new object[] { 2, "Banco do Brasil", "8492-7246-5214" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "CardNumberPrefix" },
                values: new object[] { 3, "Banco da Argentina", "2954-6344" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "CardNumberPrefix" },
                values: new object[] { 4, "Banco do Paraguai", "3647" });

            migrationBuilder.InsertData(
                table: "CashMachines",
                columns: new[] { "Id", "BankId", "AmountOne", "AmountTwo", "AmountFive", "AmountTen", "AmountTwenty", "AmountFifty", "AmountOneHundred", "AmountTwoHundred", "TotalValue" },
                values: new object[] { 1, 1, 0, 0, 0, 0, 0, 2, 0, 0, 100m });

            migrationBuilder.InsertData(
                table: "CashMachines",
                columns: new[] { "Id", "BankId", "AmountOne", "AmountTwo", "AmountFive", "AmountTen", "AmountTwenty", "AmountFifty", "AmountOneHundred", "AmountTwoHundred", "TotalValue" },
                values: new object[] { 2, 2, 52, 66, 29, 88, 43, 95, 88, 38, 23219m });

            migrationBuilder.InsertData(
                table: "CashMachines",
                columns: new[] { "Id", "BankId", "AmountOne", "AmountTwo", "AmountFive", "AmountTen", "AmountTwenty", "AmountFifty", "AmountOneHundred", "AmountTwoHundred", "TotalValue" },
                values: new object[] { 3, 3, 83, 21, 28, 93, 15, 102, 46, 59, 22995m });

            migrationBuilder.InsertData(
                table: "CashMachines",
                columns: new[] { "Id", "BankId", "AmountOne", "AmountTwo", "AmountFive", "AmountTen", "AmountTwenty", "AmountFifty", "AmountOneHundred", "AmountTwoHundred", "TotalValue" },
                values: new object[] { 4, 4, 16, 33, 52, 102, 71, 32, 84, 37, 20182m });

            migrationBuilder.InsertData(
                table: "CashMachines",
                columns: new[] { "Id", "BankId", "AmountOne", "AmountTwo", "AmountFive", "AmountTen", "AmountTwenty", "AmountFifty", "AmountOneHundred", "AmountTwoHundred", "TotalValue" },
                values: new object[] { 5, 2, 0, 0, 0, 23, 16, 8, 3, 0, 1250m });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "BankId", "CardNumber", "Balance", "Password", "Role" },
                values: new object[] { 1, "user", 1, "0000000000000000", 100m, "user", 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "BankId", "CardNumber", "Balance", "Password", "Role" },
                values: new object[] { 2, "Warren Buffett", 2, "7246058623078356", 1053214m, "user", 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "BankId", "CardNumber", "Balance", "Password", "Role" },
                values: new object[] { 3, "George Soros", 3, "2954461505550315", 520231m, "user", 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "BankId", "CardNumber", "Balance", "Password", "Role" },
                values: new object[] { 4, "Peter Lynch", 4, "3647421673211360", 880102m, "user", 1 }); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

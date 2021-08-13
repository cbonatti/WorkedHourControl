using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkedHourControl.Infra.Migrations
{
    public partial class seed_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Profile" },
                values: new object[] { 1L, "Gestor", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "Password", "Username" },
                values: new object[] { 1L, 1L, "123Mudar", "gestor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkedHourControl.Infra.Migrations
{
    public partial class add_team_to_worked_hour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TeamId",
                table: "ProjectWorkedHour",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorkedHour_TeamId",
                table: "ProjectWorkedHour",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorkedHour_Teams_TeamId",
                table: "ProjectWorkedHour",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorkedHour_Teams_TeamId",
                table: "ProjectWorkedHour");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorkedHour_TeamId",
                table: "ProjectWorkedHour");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "ProjectWorkedHour");
        }
    }
}

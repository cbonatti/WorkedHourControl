using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkedHourControl.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Profile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTeam",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(nullable: false),
                    TeamId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTeam_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorkedHour",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(nullable: false),
                    TeamId = table.Column<long>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeSpent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorkedHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectWorkedHour_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWorkedHour_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWorkedHour_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamEmployee",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<long>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamEmployee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamEmployee_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Profile" },
                values: new object[] { 1L, "Gestor", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "Password", "Username" },
                values: new object[] { 1L, 1L, "123Mudar", "gestor" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeam_ProjectId",
                table: "ProjectTeam",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeam_TeamId",
                table: "ProjectTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorkedHour_EmployeeId",
                table: "ProjectWorkedHour",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorkedHour_ProjectId",
                table: "ProjectWorkedHour",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorkedHour_TeamId",
                table: "ProjectWorkedHour",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamEmployee_EmployeeId",
                table: "TeamEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamEmployee_TeamId",
                table: "TeamEmployee",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTeam");

            migrationBuilder.DropTable(
                name: "ProjectWorkedHour");

            migrationBuilder.DropTable(
                name: "TeamEmployee");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

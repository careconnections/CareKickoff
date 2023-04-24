using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnections.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedClients = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPriority = table.Column<bool>(type: "bit", nullable: false),
                    CarePlanGoalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "BirthDate", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul", 0, "Driver" },
                    { 2, new DateTime(1985, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlet", 1, "Jonahson" },
                    { 3, new DateTime(1982, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jessica", 1, "Albo" },
                    { 4, new DateTime(1972, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jwayne", 0, "Dohnson" },
                    { 5, new DateTime(1940, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prad", 0, "Bitt" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "AuthorizedClients", "Name" },
                values: new object[,]
                {
                    { 1, "1,2,4", "Sander" },
                    { 2, "2,3", "Peter" },
                    { 3, "3,4,5", "Chris" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "CarePlanGoalId", "ClientId", "CreatedAt", "CreatedBy", "HasPriority", "Subject", "Text" },
                values: new object[,]
                {
                    { 1, "", "1", new DateTime(2019, 8, 12, 15, 22, 0, 0, DateTimeKind.Unspecified), "Sander", false, "High bloodpressure", "Client seems to have excessive lifestyle, causing high bloodpressure. Adviced to stop driving so fast." },
                    { 2, "2", "1", new DateTime(2019, 8, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), "Sander", false, "Short attention span", "Client only pays attention for 9.8 seconds" },
                    { 3, "", "1", new DateTime(2019, 8, 10, 8, 40, 0, 0, DateTimeKind.Unspecified), "Sander", true, "Burn marks", "Mr. Driver burnt his hand cooking dinner." },
                    { 4, "", "2", new DateTime(2019, 8, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), "Peter", false, "Trouble walking", "Ms. Jonahson has trouble walking for more than a few minutes at a time" },
                    { 5, "", "2", new DateTime(2019, 8, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), "Sander", false, "Random language loss", "Client sometimes seems lost trying to translate her words, and she can only speak Japanese for a few minutes" },
                    { 6, "", "2", new DateTime(2019, 8, 8, 17, 30, 0, 0, DateTimeKind.Unspecified), "Peter", false, "Quiet day", "Everything went well today" },
                    { 7, "", "3", new DateTime(2019, 8, 12, 16, 50, 0, 0, DateTimeKind.Unspecified), "Peter", false, "Quiet day", "Nothing special happened" },
                    { 8, "1", "3", new DateTime(2019, 8, 11, 15, 0, 0, 0, DateTimeKind.Unspecified), "Peter", false, "Physical exercise", "Client tried surfing today to regain mobility, went well" },
                    { 9, "1", "3", new DateTime(2019, 8, 4, 11, 19, 0, 0, DateTimeKind.Unspecified), "Chris", false, "Sprained ankle", "Ms. Albo sprained her ankle" },
                    { 10, "1", "4", new DateTime(2019, 8, 12, 15, 22, 0, 0, DateTimeKind.Unspecified), "Sander", false, "Too much protein", "Mr. Dohnson exceeded his agreed limit of maximum 5 protein shakes a day" },
                    { 11, "", "4", new DateTime(2019, 8, 10, 22, 45, 0, 0, DateTimeKind.Unspecified), "Remco", false, "Couldn't get out of bed", "Client refused to get up and stayed in bed all day" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Migrations.ApplicationDbContext_2Migrations
{
    public partial class AddDirectorysEmployeesAndServicesAlsoEditDirectoryClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    DirectoryClientsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 50, nullable: false),
                    PassportSerial = table.Column<string>(maxLength: 4, nullable: false),
                    PassportNumber = table.Column<string>(maxLength: 6, nullable: false),
                    AddressRegistration = table.Column<string>(nullable: false),
                    AddressResidential = table.Column<string>(nullable: false),
                    TelephoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DataAboutWorkPlace = table.Column<string>(nullable: false),
                    ClientDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.DirectoryClientsID);
                });

            migrationBuilder.CreateTable(
            name: "Services",
            columns: table => new
            {
                DirectoryServicesID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Service = table.Column<string>(maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Services", x => x.DirectoryServicesID);
            });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    DirectoryEmployeesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 50, nullable: false),
                    PassportSerial = table.Column<string>(maxLength: 4, nullable: false),
                    PassportNumber = table.Column<string>(maxLength: 6, nullable: false),
                    AddressRegistration = table.Column<string>(nullable: false),
                    AddressResidential = table.Column<string>(nullable: false),
                    MaritalStatus = table.Column<bool>(nullable: false),
                    TelephoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    Education = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DirectoryServicesID = table.Column<int>(nullable: false),
                    EmployeeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.DirectoryEmployeesID);
                    table.ForeignKey(
                        name: "FK_Employees_Services_DirectoryServicesID",
                        column: x => x.DirectoryServicesID,
                        principalTable: "Services",
                        principalColumn: "DirectoryServicesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DirectoryServicesID",
                table: "Employees",
                column: "DirectoryServicesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

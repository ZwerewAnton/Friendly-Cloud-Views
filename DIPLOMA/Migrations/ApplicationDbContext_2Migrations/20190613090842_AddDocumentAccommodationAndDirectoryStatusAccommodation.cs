using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Migrations.ApplicationDbContext_2Migrations
{
    public partial class AddDocumentAccommodationAndDirectoryStatusAccommodation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusAccommodation",
                columns: table => new
                {
                    DirectoryStatusAccommodationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusAccommodation = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAccommodation", x => x.DirectoryStatusAccommodationID);
                });

            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    DocumentAccommodationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DirectoryStatusAccommodationID = table.Column<int>(nullable: false),
                    DateAccommodation = table.Column<DateTime>(nullable: false),
                    DateEviction = table.Column<DateTime>(nullable: false),
                    NumberOfPersons = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 50, nullable: false),
                    PassportSerial = table.Column<string>(maxLength: 4, nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 6, nullable: true),
                    AddressRegistration = table.Column<string>(nullable: true),
                    AddressResidential = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(maxLength: 11, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DataAboutWorkPlace = table.Column<string>(nullable: true),
                    ClientDate = table.Column<DateTime>(nullable: false),
                    DirectoryCategoryRoomsID = table.Column<int>(nullable: false),
                    DirectoryTypeRoomsID = table.Column<int>(nullable: false),
                    NumberRoom = table.Column<string>(maxLength: 10, nullable: false),
                    CostPerDay = table.Column<decimal>(type: "money", nullable: false),
                    CostTotal = table.Column<decimal>(type: "money", nullable: false),
                    Payment = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.DocumentAccommodationID);
                    table.ForeignKey(
                        name: "FK_Accommodation_CategoryRooms_DirectoryCategoryRoomsID",
                        column: x => x.DirectoryCategoryRoomsID,
                        principalTable: "CategoryRooms",
                        principalColumn: "DirectoryCategoryRoomsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accommodation_StatusAccommodation_DirectoryStatusAccommodationID",
                        column: x => x.DirectoryStatusAccommodationID,
                        principalTable: "StatusAccommodation",
                        principalColumn: "DirectoryStatusAccommodationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accommodation_TypeRooms_DirectoryTypeRoomsID",
                        column: x => x.DirectoryTypeRoomsID,
                        principalTable: "TypeRooms",
                        principalColumn: "DirectoryTypeRoomsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_DirectoryCategoryRoomsID",
                table: "Accommodation",
                column: "DirectoryCategoryRoomsID");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_DirectoryStatusAccommodationID",
                table: "Accommodation",
                column: "DirectoryStatusAccommodationID");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_DirectoryTypeRoomsID",
                table: "Accommodation",
                column: "DirectoryTypeRoomsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "StatusAccommodation");
        }
    }
}

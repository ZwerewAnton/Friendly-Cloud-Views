using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Migrations.ApplicationDbContext_2Migrations
{
    public partial class EditDirectoryRooms_AddDirectoryStatusRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostPerDay",
                table: "Rooms",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DirectoryStatusRoomsID",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Repairs",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StatusRooms",
                columns: table => new
                {
                    DirectoryStatusRoomsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusRoom = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRooms", x => x.DirectoryStatusRoomsID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DirectoryStatusRoomsID",
                table: "Rooms",
                column: "DirectoryStatusRoomsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_StatusRooms_DirectoryStatusRoomsID",
                table: "Rooms",
                column: "DirectoryStatusRoomsID",
                principalTable: "StatusRooms",
                principalColumn: "DirectoryStatusRoomsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_StatusRooms_DirectoryStatusRoomsID",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "StatusRooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_DirectoryStatusRoomsID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CostPerDay",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DirectoryStatusRoomsID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Repairs",
                table: "Rooms");
        }
    }
}

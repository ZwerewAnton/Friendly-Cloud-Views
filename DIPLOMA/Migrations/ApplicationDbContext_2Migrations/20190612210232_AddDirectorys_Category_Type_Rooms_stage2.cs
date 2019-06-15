using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Migrations.ApplicationDbContext_2Migrations
{
    public partial class AddDirectorys_Category_Type_Rooms_stage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryRooms",
                columns: table => new
                {
                    DirectoryCategoryRoomsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryRoom = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRooms", x => x.DirectoryCategoryRoomsID);
                });

            migrationBuilder.CreateTable(
                name: "TypeRooms",
                columns: table => new
                {
                    DirectoryTypeRoomsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeRoom = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRooms", x => x.DirectoryTypeRoomsID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    DirectoryRoomsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DirectoryCategoryRoomsID = table.Column<int>(nullable: false),
                    DirectoryTypeRoomsID = table.Column<int>(nullable: false),
                    NumberRoom = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.DirectoryRoomsID);
                    table.ForeignKey(
                        name: "FK_Rooms_CategoryRooms_DirectoryCategoryRoomsID",
                        column: x => x.DirectoryCategoryRoomsID,
                        principalTable: "CategoryRooms",
                        principalColumn: "DirectoryCategoryRoomsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_TypeRooms_DirectoryTypeRoomsID",
                        column: x => x.DirectoryTypeRoomsID,
                        principalTable: "TypeRooms",
                        principalColumn: "DirectoryTypeRoomsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DirectoryCategoryRoomsID",
                table: "Rooms",
                column: "DirectoryCategoryRoomsID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DirectoryTypeRoomsID",
                table: "Rooms",
                column: "DirectoryTypeRoomsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "CategoryRooms");

            migrationBuilder.DropTable(
                name: "TypeRooms");
        }
    }
}

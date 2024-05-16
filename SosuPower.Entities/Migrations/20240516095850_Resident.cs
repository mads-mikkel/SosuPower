using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosuPower.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Resident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Resident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResidentId",
                table: "Tasks",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Resident_ResidentId",
                table: "Tasks",
                column: "ResidentId",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Resident_ResidentId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ResidentId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "Tasks");
        }
    }
}

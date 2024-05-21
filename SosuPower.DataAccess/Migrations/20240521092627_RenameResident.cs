using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosuPower.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameResident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Resident_ResidentId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resident",
                table: "Resident");

            migrationBuilder.RenameTable(
                name: "Resident",
                newName: "Residents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residents",
                table: "Residents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Residents_ResidentId",
                table: "Tasks",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Residents_ResidentId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residents",
                table: "Residents");

            migrationBuilder.RenameTable(
                name: "Residents",
                newName: "Resident");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resident",
                table: "Resident",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Resident_ResidentId",
                table: "Tasks",
                column: "ResidentId",
                principalTable: "Resident",
                principalColumn: "Id");
        }
    }
}

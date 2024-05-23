using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosuPower.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Task2Assignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentEmployee_Tasks_TasksId",
                table: "AssignmentEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentEmployee",
                table: "AssignmentEmployee");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentEmployee_TasksId",
                table: "AssignmentEmployee");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "AssignmentEmployee",
                newName: "AssignmentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentEmployee",
                table: "AssignmentEmployee",
                columns: new[] { "AssignmentsId", "EmployeesId" });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEmployee_EmployeesId",
                table: "AssignmentEmployee",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentEmployee_Tasks_AssignmentsId",
                table: "AssignmentEmployee",
                column: "AssignmentsId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentEmployee_Tasks_AssignmentsId",
                table: "AssignmentEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentEmployee",
                table: "AssignmentEmployee");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentEmployee_EmployeesId",
                table: "AssignmentEmployee");

            migrationBuilder.RenameColumn(
                name: "AssignmentsId",
                table: "AssignmentEmployee",
                newName: "TasksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentEmployee",
                table: "AssignmentEmployee",
                columns: new[] { "EmployeesId", "TasksId" });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEmployee_TasksId",
                table: "AssignmentEmployee",
                column: "TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentEmployee_Tasks_TasksId",
                table: "AssignmentEmployee",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

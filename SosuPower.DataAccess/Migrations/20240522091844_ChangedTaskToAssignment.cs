using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosuPower.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTaskToAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTask");

            migrationBuilder.CreateTable(
                name: "AssignmentEmployee",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentEmployee", x => new { x.EmployeesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_AssignmentEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentEmployee_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEmployee_TasksId",
                table: "AssignmentEmployee",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentEmployee");

            migrationBuilder.CreateTable(
                name: "EmployeeTask",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTask", x => new { x.EmployeesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_TasksId",
                table: "EmployeeTask",
                column: "TasksId");
        }
    }
}

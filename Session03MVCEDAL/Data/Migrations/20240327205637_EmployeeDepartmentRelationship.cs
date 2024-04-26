using Microsoft.EntityFrameworkCore.Migrations;

namespace Session03MVCEDAL.Data.Migrations
{
    public partial class EmployeeDepartmentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmetId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmetId",
                table: "Employees",
                column: "DepartmetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmetId",
                table: "Employees",
                column: "DepartmetId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmetId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmetId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmetId",
                table: "Employees");
        }
    }
}

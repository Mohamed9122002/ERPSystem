using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSystem.DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumSalaryAndGenderandAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                schema: "HR",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                schema: "HR",
                table: "Employees",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Salary",
                schema: "HR",
                table: "Employees");
        }
    }
}

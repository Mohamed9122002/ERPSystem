using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSystem.DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumEmployeeTypeAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "HR",
                table: "Employees",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                schema: "HR",
                table: "Employees");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSystem.DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModuleAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAbsent",
                schema: "HR",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "LateHours",
                schema: "HR",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OvertimeHours",
                schema: "HR",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkingHours",
                schema: "HR",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbsent",
                schema: "HR",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "LateHours",
                schema: "HR",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "OvertimeHours",
                schema: "HR",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                schema: "HR",
                table: "Attendances");
        }
    }
}

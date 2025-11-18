using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSystem.DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainingConfigurationAndChangeSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTraining_Employees_EmployeeId",
                table: "EmployeeTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTraining_Training_TrainingId",
                table: "EmployeeTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTraining",
                table: "EmployeeTraining");

            migrationBuilder.RenameTable(
                name: "Training",
                newName: "Trainings",
                newSchema: "HR");

            migrationBuilder.RenameTable(
                name: "EmployeeTraining",
                newName: "EmployeeTrainings",
                newSchema: "HR");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                schema: "HR",
                table: "Trainings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTraining_TrainingId",
                schema: "HR",
                table: "EmployeeTrainings",
                newName: "IX_EmployeeTrainings_TrainingId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "HR",
                table: "Trainings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "HR",
                table: "Trainings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "HR",
                table: "Trainings",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "HR",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "HR",
                table: "Trainings",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GetDate()");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "HR",
                table: "Trainings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                schema: "HR",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                schema: "HR",
                table: "Trainings",
                type: "datetime2",
                nullable: true,
                computedColumnSql: "GetDate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainings",
                schema: "HR",
                table: "Trainings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTrainings",
                schema: "HR",
                table: "EmployeeTrainings",
                columns: new[] { "EmployeeId", "TrainingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainings_Employees_EmployeeId",
                schema: "HR",
                table: "EmployeeTrainings",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainings_Trainings_TrainingId",
                schema: "HR",
                table: "EmployeeTrainings",
                column: "TrainingId",
                principalSchema: "HR",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainings_Employees_EmployeeId",
                schema: "HR",
                table: "EmployeeTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainings_Trainings_TrainingId",
                schema: "HR",
                table: "EmployeeTrainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainings",
                schema: "HR",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTrainings",
                schema: "HR",
                table: "EmployeeTrainings");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                schema: "HR",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "HR",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "HR",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "HR",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "HR",
                table: "Trainings");

            migrationBuilder.RenameTable(
                name: "Trainings",
                schema: "HR",
                newName: "Training");

            migrationBuilder.RenameTable(
                name: "EmployeeTrainings",
                schema: "HR",
                newName: "EmployeeTraining");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Training",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTrainings_TrainingId",
                table: "EmployeeTraining",
                newName: "IX_EmployeeTraining_TrainingId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Training",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Training",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Training",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training",
                table: "Training",
                column: "TrainingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTraining",
                table: "EmployeeTraining",
                columns: new[] { "EmployeeId", "TrainingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTraining_Employees_EmployeeId",
                table: "EmployeeTraining",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTraining_Training_TrainingId",
                table: "EmployeeTraining",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

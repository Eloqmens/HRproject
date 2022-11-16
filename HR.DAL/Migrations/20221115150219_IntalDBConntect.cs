using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.DAL.Migrations
{
    public partial class IntalDBConntect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateofBirth",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionId",
                table: "Positions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentId",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_DepartmentId",
                table: "Departments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Positions_PositionId",
                table: "Positions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_DepartmentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Positions_PositionId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_PositionId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Departments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofBirth",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Passport",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

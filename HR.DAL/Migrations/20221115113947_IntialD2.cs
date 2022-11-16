using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.DAL.Migrations
{
    public partial class IntialD2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentsId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionsId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropColumn(
                name: "DatedJoined",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PositionsId",
                table: "Employees",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "DepartmentsId",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionsId",
                table: "Employees",
                newName: "IX_Employees_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentsId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Employees",
                newName: "PositionsId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "DepartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                newName: "IX_Employees_PositionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentsId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatedJoined",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_EmployeeId",
                table: "Hospitals",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentsId",
                table: "Employees",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionsId",
                table: "Employees",
                column: "PositionsId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureProspects.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Experiance",
                table: "Employees",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Employees",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Employees",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Employees",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experiance",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Employees");
        }
    }
}

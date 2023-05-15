using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureProspects.Migrations
{
    /// <inheritdoc />
    public partial class EmpolerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Empolyers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Empolyers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CompadnyDescription",
                table: "Empolyers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Empolyers",
                type: "varchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Empolyers",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Empolyers",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Empolyers",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Empolyers");

            migrationBuilder.DropColumn(
                name: "CompadnyDescription",
                table: "Empolyers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Empolyers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Empolyers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Empolyers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Empolyers");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Empolyers",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

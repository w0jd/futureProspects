using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureProspects.Migrations
{
    /// <inheritdoc />
    public partial class OffersUpadate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Empolyers_EmpolyerId",
                table: "Offer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offer",
                table: "Offer");

            migrationBuilder.RenameTable(
                name: "Offer",
                newName: "Offers");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_EmpolyerId",
                table: "Offers",
                newName: "IX_Offers_EmpolyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Empolyers_EmpolyerId",
                table: "Offers",
                column: "EmpolyerId",
                principalTable: "Empolyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Empolyers_EmpolyerId",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "Offer");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_EmpolyerId",
                table: "Offer",
                newName: "IX_Offer_EmpolyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offer",
                table: "Offer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Empolyers_EmpolyerId",
                table: "Offer",
                column: "EmpolyerId",
                principalTable: "Empolyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

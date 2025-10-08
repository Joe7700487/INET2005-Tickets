using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeTickets.Migrations
{
    /// <inheritdoc />
    public partial class Navigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Listing_ListingId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ListingId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Listing",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listing_CategoryId",
                table: "Listing",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Category_CategoryId",
                table: "Listing",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Category_CategoryId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_CategoryId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Listing");

            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ListingId",
                table: "Category",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Listing_ListingId",
                table: "Category",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "ListingId");
        }
    }
}

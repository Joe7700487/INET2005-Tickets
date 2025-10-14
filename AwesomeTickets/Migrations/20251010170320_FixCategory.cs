using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeTickets.Migrations
{
    /// <inheritdoc />
    public partial class FixCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListingCategory",
                table: "Listing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListingCategory",
                table: "Listing",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

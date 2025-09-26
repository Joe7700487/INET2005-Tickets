using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeTickets.Migrations
{
    /// <inheritdoc />
    public partial class CreateListingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    ListingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.ListingId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "ListingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ListingId",
                table: "Category",
                column: "ListingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Listing");
        }
    }
}

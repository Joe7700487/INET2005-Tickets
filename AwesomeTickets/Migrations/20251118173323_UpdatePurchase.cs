using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeTickets.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Listing_ListingId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Purchase");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Tickets",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Listing_ListingId",
                table: "Purchase",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "ListingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Listing_ListingId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Tickets",
                table: "Purchase");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Purchase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Purchase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Listing_ListingId",
                table: "Purchase",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "ListingId");
        }
    }
}

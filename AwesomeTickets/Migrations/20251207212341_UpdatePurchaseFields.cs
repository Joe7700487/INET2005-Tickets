using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeTickets.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePurchaseFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Purchase");

            migrationBuilder.AddColumn<string>(
                name: "CCV",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Expiry",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CCV",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Expiry",
                table: "Purchase");

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

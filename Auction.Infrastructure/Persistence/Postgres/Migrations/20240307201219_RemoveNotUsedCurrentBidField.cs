using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.Infrastructure.Persistence.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNotUsedCurrentBidField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBid",
                table: "AuctionItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBid",
                table: "AuctionItems",
                type: "numeric",
                nullable: true);
        }
    }
}

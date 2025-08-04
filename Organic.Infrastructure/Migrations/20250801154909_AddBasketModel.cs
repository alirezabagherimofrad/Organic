using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBasketModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "OrderItemModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "baskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baskets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemModel_BasketId",
                table: "OrderItemModel",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemModel_baskets_BasketId",
                table: "OrderItemModel",
                column: "BasketId",
                principalTable: "baskets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemModel_baskets_BasketId",
                table: "OrderItemModel");

            migrationBuilder.DropTable(
                name: "baskets");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemModel_BasketId",
                table: "OrderItemModel");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "OrderItemModel");
        }
    }
}

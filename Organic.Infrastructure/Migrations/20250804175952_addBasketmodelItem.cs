using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addBasketmodelItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemModel_baskets_BasketId",
                table: "OrderItemModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemModel_BasketId",
                table: "OrderItemModel");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "OrderItemModel");

            migrationBuilder.CreateTable(
                name: "basketItemModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basketItemModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_basketItemModels_baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "baskets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_basketItemModels_BasketId",
                table: "basketItemModels",
                column: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basketItemModels");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "OrderItemModel",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}

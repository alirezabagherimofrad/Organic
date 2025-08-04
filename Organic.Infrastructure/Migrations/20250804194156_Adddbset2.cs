using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adddbset2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemModel_OrderModel_OrderId",
                table: "OrderItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemModel_ProductModel_ProductId",
                table: "OrderItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_AddressModel_AddressId",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemModel",
                table: "OrderItemModel");

            migrationBuilder.RenameTable(
                name: "OrderModel",
                newName: "orderModels");

            migrationBuilder.RenameTable(
                name: "OrderItemModel",
                newName: "orderItemModels");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_AddressId",
                table: "orderModels",
                newName: "IX_orderModels_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemModel_ProductId",
                table: "orderItemModels",
                newName: "IX_orderItemModels_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemModel_OrderId",
                table: "orderItemModels",
                newName: "IX_orderItemModels_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderModels",
                table: "orderModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItemModels",
                table: "orderItemModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItemModels_ProductModel_ProductId",
                table: "orderItemModels",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItemModels_orderModels_OrderId",
                table: "orderItemModels",
                column: "OrderId",
                principalTable: "orderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderModels_AddressModel_AddressId",
                table: "orderModels",
                column: "AddressId",
                principalTable: "AddressModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItemModels_ProductModel_ProductId",
                table: "orderItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItemModels_orderModels_OrderId",
                table: "orderItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_orderModels_AddressModel_AddressId",
                table: "orderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderModels",
                table: "orderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItemModels",
                table: "orderItemModels");

            migrationBuilder.RenameTable(
                name: "orderModels",
                newName: "OrderModel");

            migrationBuilder.RenameTable(
                name: "orderItemModels",
                newName: "OrderItemModel");

            migrationBuilder.RenameIndex(
                name: "IX_orderModels_AddressId",
                table: "OrderModel",
                newName: "IX_OrderModel_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItemModels_ProductId",
                table: "OrderItemModel",
                newName: "IX_OrderItemModel_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItemModels_OrderId",
                table: "OrderItemModel",
                newName: "IX_OrderItemModel_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemModel",
                table: "OrderItemModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemModel_OrderModel_OrderId",
                table: "OrderItemModel",
                column: "OrderId",
                principalTable: "OrderModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemModel_ProductModel_ProductId",
                table: "OrderItemModel",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_AddressModel_AddressId",
                table: "OrderModel",
                column: "AddressId",
                principalTable: "AddressModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

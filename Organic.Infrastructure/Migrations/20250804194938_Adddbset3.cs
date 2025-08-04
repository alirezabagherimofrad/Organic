using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adddbset3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PK_AddressModel",
                table: "AddressModel");

            migrationBuilder.RenameTable(
                name: "orderModels",
                newName: "OrderModels");

            migrationBuilder.RenameTable(
                name: "AddressModel",
                newName: "addressModels");

            migrationBuilder.RenameIndex(
                name: "IX_orderModels_AddressId",
                table: "OrderModels",
                newName: "IX_OrderModels_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addressModels",
                table: "addressModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "discountModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    DurationDays = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discountModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_discountModels_ProductModel_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discountModels_ProductId",
                table: "discountModels",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItemModels_OrderModels_OrderId",
                table: "orderItemModels",
                column: "OrderId",
                principalTable: "OrderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModels_addressModels_AddressId",
                table: "OrderModels",
                column: "AddressId",
                principalTable: "addressModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItemModels_OrderModels_OrderId",
                table: "orderItemModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_addressModels_AddressId",
                table: "OrderModels");

            migrationBuilder.DropTable(
                name: "discountModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addressModels",
                table: "addressModels");

            migrationBuilder.RenameTable(
                name: "OrderModels",
                newName: "orderModels");

            migrationBuilder.RenameTable(
                name: "addressModels",
                newName: "AddressModel");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_AddressId",
                table: "orderModels",
                newName: "IX_orderModels_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderModels",
                table: "orderModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel",
                column: "Id");

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
    }
}

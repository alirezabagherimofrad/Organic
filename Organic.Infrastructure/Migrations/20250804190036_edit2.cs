using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageModel_ProductModel_ProductId",
                table: "ProductImageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImageModel",
                table: "ProductImageModel");

            migrationBuilder.RenameTable(
                name: "ProductImageModel",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImageModel_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductModel_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductModel_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImageModel");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImageModel",
                newName: "IX_ProductImageModel_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImageModel",
                table: "ProductImageModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageModel_ProductModel_ProductId",
                table: "ProductImageModel",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

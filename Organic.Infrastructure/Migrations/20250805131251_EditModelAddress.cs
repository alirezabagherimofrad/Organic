using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditModelAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basketItemModels_baskets_BasketId",
                table: "basketItemModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "BasketId",
                table: "basketItemModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "addressModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_addressModels_UserId",
                table: "addressModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_addressModels_User_UserId",
                table: "addressModels",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_basketItemModels_baskets_BasketId",
                table: "basketItemModels",
                column: "BasketId",
                principalTable: "baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addressModels_User_UserId",
                table: "addressModels");

            migrationBuilder.DropForeignKey(
                name: "FK_basketItemModels_baskets_BasketId",
                table: "basketItemModels");

            migrationBuilder.DropIndex(
                name: "IX_addressModels_UserId",
                table: "addressModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "addressModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "BasketId",
                table: "basketItemModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_basketItemModels_baskets_BasketId",
                table: "basketItemModels",
                column: "BasketId",
                principalTable: "baskets",
                principalColumn: "Id");
        }
    }
}

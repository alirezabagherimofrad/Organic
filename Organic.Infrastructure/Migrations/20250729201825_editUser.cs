using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategoryModel_CatrgoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_uploadeUserPicthers_userModels_UserId",
                table: "uploadeUserPicthers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userModels",
                table: "userModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uploadeUserPicthers",
                table: "uploadeUserPicthers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "userModels",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "uploadeUserPicthers",
                newName: "UserImage");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImageModel");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "ProductModel");

            migrationBuilder.RenameIndex(
                name: "IX_uploadeUserPicthers_UserId",
                table: "UserImage",
                newName: "IX_UserImage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImageModel",
                newName: "IX_ProductImageModel_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CatrgoryId",
                table: "ProductModel",
                newName: "IX_ProductModel_CatrgoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserImage",
                table: "UserImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImageModel",
                table: "ProductImageModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageModel_ProductModel_ProductId",
                table: "ProductImageModel",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_ProductCategoryModel_CatrgoryId",
                table: "ProductModel",
                column: "CatrgoryId",
                principalTable: "ProductCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImage_User_UserId",
                table: "UserImage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageModel_ProductModel_ProductId",
                table: "ProductImageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_ProductCategoryModel_CatrgoryId",
                table: "ProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImage_User_UserId",
                table: "UserImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserImage",
                table: "UserImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImageModel",
                table: "ProductImageModel");

            migrationBuilder.RenameTable(
                name: "UserImage",
                newName: "uploadeUserPicthers");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "userModels");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductImageModel",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_UserImage_UserId",
                table: "uploadeUserPicthers",
                newName: "IX_uploadeUserPicthers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModel_CatrgoryId",
                table: "Product",
                newName: "IX_Product_CatrgoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImageModel_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uploadeUserPicthers",
                table: "uploadeUserPicthers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userModels",
                table: "userModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategoryModel_CatrgoryId",
                table: "Product",
                column: "CatrgoryId",
                principalTable: "ProductCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uploadeUserPicthers_userModels_UserId",
                table: "uploadeUserPicthers",
                column: "UserId",
                principalTable: "userModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

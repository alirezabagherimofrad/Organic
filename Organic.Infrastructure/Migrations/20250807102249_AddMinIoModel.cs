using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMinIoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountDuration",
                table: "ProductModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "ProductModel",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "miniomodels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_miniomodels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "miniomodels");

            migrationBuilder.DropColumn(
                name: "DiscountDuration",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "ProductModel");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "userModels");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "userModels",
                newName: "Last_Name");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "userModels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "userModels");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "userModels",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "userModels",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}

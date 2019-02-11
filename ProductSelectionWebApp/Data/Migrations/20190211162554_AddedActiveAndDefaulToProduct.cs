using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductSelectionWebApp.Data.Migrations
{
    public partial class AddedActiveAndDefaulToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Product");
        }
    }
}

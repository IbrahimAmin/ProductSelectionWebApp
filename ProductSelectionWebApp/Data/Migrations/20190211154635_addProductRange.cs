using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductSelectionWebApp.Data.Migrations
{
    public partial class addProductRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Range",
                table: "Product",
                newName: "Note");

            migrationBuilder.AddColumn<int>(
                name: "RangeId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_RangeId",
                table: "Product",
                column: "RangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Range_RangeId",
                table: "Product",
                column: "RangeId",
                principalTable: "Range",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Range_RangeId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_RangeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RangeId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Product",
                newName: "Range");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductSelectionWebApp.Data.Migrations
{
    public partial class ProductEntityRangeString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_BuildingAreaId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Range_RangeId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BuildingAreaId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_RangeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BuildingAreaId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RangeId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "Range");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelNumber",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModelNumber",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Range",
                table: "Product",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "BuildingAreaId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RangeId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_BuildingAreaId",
                table: "Product",
                column: "BuildingAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_RangeId",
                table: "Product",
                column: "RangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_BuildingAreaId",
                table: "Product",
                column: "BuildingAreaId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Range_RangeId",
                table: "Product",
                column: "RangeId",
                principalTable: "Range",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

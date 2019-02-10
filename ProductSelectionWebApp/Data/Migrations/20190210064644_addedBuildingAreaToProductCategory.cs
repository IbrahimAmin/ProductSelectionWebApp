using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductSelectionWebApp.Data.Migrations
{
    public partial class addedBuildingAreaToProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingAreaId",
                table: "ProductCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildingArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUtc = table.Column<DateTime>(nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingArea", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_BuildingAreaId",
                table: "ProductCategory",
                column: "BuildingAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_BuildingArea_BuildingAreaId",
                table: "ProductCategory",
                column: "BuildingAreaId",
                principalTable: "BuildingArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_BuildingArea_BuildingAreaId",
                table: "ProductCategory");

            migrationBuilder.DropTable(
                name: "BuildingArea");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_BuildingAreaId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "BuildingAreaId",
                table: "ProductCategory");
        }
    }
}

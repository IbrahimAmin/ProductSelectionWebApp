using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductSelectionWebApp.Data.Migrations
{
    public partial class addRangePropertyCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rnage",
                table: "Range",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Range",
                newName: "Rnage");
        }
    }
}

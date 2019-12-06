using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addHoanVenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "number",
                table: "HoanVeModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number",
                table: "HoanVeModels");
        }
    }
}

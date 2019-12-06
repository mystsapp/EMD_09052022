using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addHoanVengcapnhat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nguoicapnhat",
                table: "HoanVeModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nguoicapnhat",
                table: "HoanVeModels");
        }
    }
}

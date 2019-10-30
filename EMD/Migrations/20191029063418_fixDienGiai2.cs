using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class fixDienGiai2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DienGiai",
                table: "EMDs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DienGiai",
                table: "EMDs");
        }
    }
}

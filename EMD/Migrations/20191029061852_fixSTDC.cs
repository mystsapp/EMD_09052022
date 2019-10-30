using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class fixSTDC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STDatCoc",
                table: "EMDs");

            migrationBuilder.AddColumn<decimal>(
                name: "STDatCoc1",
                table: "EMDs",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STDatCoc1",
                table: "EMDs");

            migrationBuilder.AddColumn<decimal>(
                name: "STDatCoc",
                table: "EMDs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

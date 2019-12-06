using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addHVCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SLVeHoan",
                table: "EMDs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThucTra",
                table: "EMDs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLVeHoan",
                table: "EMDs");

            migrationBuilder.DropColumn(
                name: "ThucTra",
                table: "EMDs");
        }
    }
}

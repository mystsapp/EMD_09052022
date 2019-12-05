using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class removeCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hanghk",
                table: "DienGiaiModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hanghk",
                table: "DienGiaiModels",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

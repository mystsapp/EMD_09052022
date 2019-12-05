using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addMoreCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hanghk",
                table: "DienGiaiModels",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nguoinhap",
                table: "DienGiaiModels",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hanghk",
                table: "DienGiaiModels");

            migrationBuilder.DropColumn(
                name: "nguoinhap",
                table: "DienGiaiModels");
        }
    }
}

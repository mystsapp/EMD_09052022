using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addnumberCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "number",
                table: "DienGiaiModels",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number",
                table: "DienGiaiModels");
        }
    }
}

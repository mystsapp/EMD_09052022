using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class modifyDMDaiLy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VanPhong",
                table: "Users",
                newName: "DMDaiLy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DMDaiLy",
                table: "Users",
                newName: "VanPhong");
        }
    }
}

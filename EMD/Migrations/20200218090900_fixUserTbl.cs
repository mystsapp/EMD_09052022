using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class fixUserTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "MaCN",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTao",
                table: "Users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrangThai",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaCN",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NguoiTao",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "TinhTrang",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

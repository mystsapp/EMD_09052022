using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addEmdCanTruTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMDCanTrus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    OldNumber = table.Column<string>(nullable: true),
                    LoaiBK = table.Column<string>(nullable: true),
                    TimThay = table.Column<bool>(nullable: false),
                    UserNhap = table.Column<string>(nullable: true),
                    NgayNhap = table.Column<DateTime>(nullable: false),
                    UserXoa = table.Column<string>(nullable: true),
                    NgayXoa = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMDCanTrus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginViewModels",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Mact = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Trangthai = table.Column<bool>(nullable: false),
                    Doimk = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginViewModels", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMDCanTrus");

            migrationBuilder.DropTable(
                name: "LoginViewModels");
        }
    }
}

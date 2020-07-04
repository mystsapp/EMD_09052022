using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addNeColEmdCanTru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySua",
                table: "EMDCanTrus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserSua",
                table: "EMDCanTrus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgaySua",
                table: "EMDCanTrus");

            migrationBuilder.DropColumn(
                name: "UserSua",
                table: "EMDCanTrus");
        }
    }
}

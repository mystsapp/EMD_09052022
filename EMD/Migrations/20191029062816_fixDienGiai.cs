using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class fixDienGiai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs");

            migrationBuilder.DropColumn(
                name: "EMDTblId",
                table: "EMDs");

            migrationBuilder.DropColumn(
                name: "DienGiai",
                table: "EMDs");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EMDs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "DienGiai1",
                table: "EMDs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EMDs");

            migrationBuilder.DropColumn(
                name: "DienGiai1",
                table: "EMDs");

            migrationBuilder.AddColumn<int>(
                name: "EMDTblId",
                table: "EMDs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "DienGiai",
                table: "EMDs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs",
                column: "EMDTblId");
        }
    }
}

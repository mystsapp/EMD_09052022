using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class changeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EMDs");

            migrationBuilder.AddColumn<int>(
                name: "EMDTblId",
                table: "EMDs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs",
                column: "EMDTblId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs");

            migrationBuilder.DropColumn(
                name: "EMDTblId",
                table: "EMDs");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EMDs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMDs",
                table: "EMDs",
                column: "Id");
        }
    }
}

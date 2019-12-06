using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class fixCol1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "thuctra",
                table: "HoanVeModels");

            migrationBuilder.DropColumn(
                name: "tongthanhtoan",
                table: "HoanVeModels");

            migrationBuilder.AddColumn<decimal>(
                name: "giave",
                table: "HoanVeModels",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "lephi",
                table: "HoanVeModels",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "phidv",
                table: "HoanVeModels",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "thuesb",
                table: "HoanVeModels",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "thuevat",
                table: "HoanVeModels",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "giave",
                table: "HoanVeModels");

            migrationBuilder.DropColumn(
                name: "lephi",
                table: "HoanVeModels");

            migrationBuilder.DropColumn(
                name: "phidv",
                table: "HoanVeModels");

            migrationBuilder.DropColumn(
                name: "thuesb",
                table: "HoanVeModels");

            migrationBuilder.DropColumn(
                name: "thuevat",
                table: "HoanVeModels");

            migrationBuilder.AddColumn<decimal>(
                name: "thuctra",
                table: "HoanVeModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "tongthanhtoan",
                table: "HoanVeModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

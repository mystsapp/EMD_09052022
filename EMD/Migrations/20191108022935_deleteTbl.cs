using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class deleteTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DienGiaiModels");

            migrationBuilder.DropTable(
                name: "SGTCodeModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DienGiaiModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    giave = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lephi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nguoicapnhat = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    phidv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sgtcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    slve = table.Column<int>(type: "int", nullable: false),
                    thuesb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    thuevat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DienGiaiModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SGTCodeModels",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    batdau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diemtq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ketthuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sgtcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sokhach = table.Column<int>(type: "int", nullable: false),
                    tuyentq = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGTCodeModels", x => x.Id);
                });
        }
    }
}

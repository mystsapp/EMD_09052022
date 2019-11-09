using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addSGTCodeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SGTCodeModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sgtcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    batdau = table.Column<DateTime>(nullable: false),
                    ketthuc = table.Column<DateTime>(nullable: false),
                    diemtq = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    tuyentq = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    sokhach = table.Column<int>(nullable: false),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    slve = table.Column<int>(nullable: false),
                    nguoicapnhat = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    giave = table.Column<decimal>(nullable: false),
                    lephi = table.Column<decimal>(nullable: false),
                    thuesb = table.Column<decimal>(nullable: false),
                    thuevat = table.Column<decimal>(nullable: false),
                    phidv = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGTCodeModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SGTCodeModels");
        }
    }
}

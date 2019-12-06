using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class addHoanVeTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoanVeModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sgtcode = table.Column<string>(nullable: true),
                    slve = table.Column<string>(nullable: true),
                    tongthanhtoan = table.Column<string>(nullable: true),
                    phihoan = table.Column<string>(nullable: true),
                    thuctra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoanVeModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoanVeModels");
        }
    }
}

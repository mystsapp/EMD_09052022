using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMD.Migrations
{
    public partial class InitDBLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiNhanhs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChiNhanh = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DienThoai = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DienGiaiModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sgtcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    slve = table.Column<int>(nullable: false),
                    nguoicapnhat = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    giave = table.Column<decimal>(nullable: false),
                    lephi = table.Column<decimal>(nullable: false),
                    thuesb = table.Column<decimal>(nullable: false),
                    thuevat = table.Column<decimal>(nullable: false),
                    phidv = table.Column<decimal>(nullable: false),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    nguoinhap = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DienGiaiModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMDCanTrus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    OldNumber = table.Column<string>(nullable: true),
                    LoaiBK = table.Column<string>(nullable: true),
                    TimThay = table.Column<bool>(nullable: false),
                    STDatCoc = table.Column<decimal>(nullable: false),
                    UserNhap = table.Column<string>(nullable: true),
                    NgayNhap = table.Column<DateTime>(nullable: false),
                    UserXoa = table.Column<string>(nullable: true),
                    NgayXoa = table.Column<DateTime>(nullable: false),
                    UserSua = table.Column<string>(nullable: true),
                    NgaySua = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMDCanTrus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SGTCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BatDau = table.Column<DateTime>(nullable: false),
                    KetThuc = table.Column<DateTime>(nullable: false),
                    SLVeDatCoc = table.Column<int>(nullable: false),
                    NgayDC = table.Column<DateTime>(nullable: true),
                    HetHan = table.Column<DateTime>(nullable: true),
                    Number = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    HangHK = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    STDatCoc = table.Column<decimal>(nullable: false),
                    HoanCoc = table.Column<DateTime>(nullable: true),
                    LoaiBK = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SLVeDaXuat = table.Column<int>(nullable: false),
                    TienXuatVe = table.Column<decimal>(nullable: false),
                    TienPhat = table.Column<decimal>(nullable: false),
                    NgayPhat = table.Column<DateTime>(nullable: true),
                    SoCTPhat = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LoaiTien = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TyGia = table.Column<decimal>(nullable: false),
                    GhiChu = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DongHoSo = table.Column<DateTime>(nullable: true),
                    Create = table.Column<DateTime>(nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NgaySua = table.Column<DateTime>(nullable: true),
                    NguoiNhap = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Tracking = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PNR = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DaHoanCoc = table.Column<bool>(nullable: false),
                    DienGiai = table.Column<string>(nullable: true),
                    SLVeHoan = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ThucTra = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CanTru = table.Column<bool>(nullable: false),
                    UserXoa = table.Column<string>(nullable: true),
                    NgayXoa = table.Column<DateTime>(nullable: false),
                    LogFile = table.Column<string>(nullable: true),
                    Xoa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangHKs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHKs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoanVeModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sgtcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    slve = table.Column<int>(nullable: false),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    giave = table.Column<decimal>(nullable: false),
                    thuesb = table.Column<decimal>(nullable: false),
                    lephi = table.Column<decimal>(nullable: false),
                    thuevat = table.Column<decimal>(nullable: false),
                    phidv = table.Column<decimal>(nullable: false),
                    phihoan = table.Column<decimal>(nullable: false),
                    nguoicapnhat = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoanVeModels", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Trangthai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SGTCodeModels",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    sgtcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    batdau = table.Column<DateTime>(nullable: false),
                    ketthuc = table.Column<DateTime>(nullable: false),
                    diemtq = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    tuyentq = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    sokhach = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGTCodeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMDaiLies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DienThoai = table.Column<string>(maxLength: 15, nullable: true),
                    ChiNhanhId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMDaiLies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMDaiLies_ChiNhanhs_ChiNhanhId",
                        column: x => x.ChiNhanhId,
                        principalTable: "ChiNhanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Khoi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ChiNhanhId = table.Column<int>(nullable: false),
                    MaCN = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DMDaiLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Doimk = table.Column<bool>(nullable: true),
                    Ngaydoimk = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ChiNhanhs_ChiNhanhId",
                        column: x => x.ChiNhanhId,
                        principalTable: "ChiNhanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DMDaiLies_ChiNhanhId",
                table: "DMDaiLies",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChiNhanhId",
                table: "Users",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DienGiaiModels");

            migrationBuilder.DropTable(
                name: "DMDaiLies");

            migrationBuilder.DropTable(
                name: "EMDCanTrus");

            migrationBuilder.DropTable(
                name: "EMDs");

            migrationBuilder.DropTable(
                name: "HangHKs");

            migrationBuilder.DropTable(
                name: "HoanVeModels");

            migrationBuilder.DropTable(
                name: "LoginViewModels");

            migrationBuilder.DropTable(
                name: "SGTCodeModels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ChiNhanhs");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

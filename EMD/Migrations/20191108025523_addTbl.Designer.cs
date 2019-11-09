﻿// <auto-generated />
using System;
using EMD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMD.Migrations
{
    [DbContext(typeof(EMDDbContext))]
    [Migration("20191108025523_addTbl")]
    partial class addTbl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMD.Data.Models.ChiNhanh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("DienThoai")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MaChiNhanh")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ChiNhanhs");
                });

            modelBuilder.Entity("EMD.Data.Models.DMDaiLy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChiNhanhId")
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("DienThoai")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ChiNhanhId");

                    b.ToTable("DMDaiLies");
                });

            modelBuilder.Entity("EMD.Data.Models.DienGiaiModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("giave")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("lephi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("nguoicapnhat")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("number")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("phidv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("sgtcode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("slve")
                        .HasColumnType("int");

                    b.Property<decimal>("thuesb")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("thuevat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DienGiaiModels");
                });

            modelBuilder.Entity("EMD.Data.Models.EMDTbl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BatDau")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Create")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DaHoanCoc")
                        .HasColumnType("bit");

                    b.Property<string>("DienGiai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DongHoSo")
                        .HasColumnType("datetime2");

                    b.Property<string>("GhiChu")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("HangHK")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("HetHan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HoanCoc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KetThuc")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("LoaiBK")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LoaiTien")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("NgayDC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayPhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiNhap")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Number")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("PNR")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SGTCode")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SLVeDaXuat")
                        .HasColumnType("int");

                    b.Property<int>("SLVeDatCoc")
                        .HasColumnType("int");

                    b.Property<decimal>("STDatCoc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SoCTPhat")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("TienPhat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TienXuatVe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tracking")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("TyGia")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("EMDs");
                });

            modelBuilder.Entity("EMD.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Trangthai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EMD.Data.Models.SGTCodeModel", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("batdau")
                        .HasColumnType("datetime2");

                    b.Property<string>("diemtq")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("ketthuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("sgtcode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("sokhach")
                        .HasColumnType("int");

                    b.Property<string>("tuyentq")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("SGTCodeModels");
                });

            modelBuilder.Entity("EMD.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChiNhanhId")
                        .HasColumnType("int");

                    b.Property<string>("DMDaiLy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Doimk")
                        .HasColumnType("bit");

                    b.Property<string>("Khoi")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("Ngaydoimk")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhongBan")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ChiNhanhId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EMD.Data.Models.DMDaiLy", b =>
                {
                    b.HasOne("EMD.Data.Models.ChiNhanh", "ChiNhanh")
                        .WithMany()
                        .HasForeignKey("ChiNhanhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMD.Data.Models.User", b =>
                {
                    b.HasOne("EMD.Data.Models.ChiNhanh", "ChiNhanh")
                        .WithMany()
                        .HasForeignKey("ChiNhanhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMD.Data.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

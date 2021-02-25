using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMD.Models_1
{
    public partial class EMDContext : DbContext
    {
        public EMDContext()
        {
        }

        public EMDContext(DbContextOptions<EMDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiNhanhs> ChiNhanhs { get; set; }
        public virtual DbSet<DienGiaiModels> DienGiaiModels { get; set; }
        public virtual DbSet<DmdaiLies> DmdaiLies { get; set; }
        public virtual DbSet<EmdcanTrus> EmdcanTrus { get; set; }
        public virtual DbSet<Emds> Emds { get; set; }
        public virtual DbSet<HangHks> HangHks { get; set; }
        public virtual DbSet<HoanVeModels> HoanVeModels { get; set; }
        public virtual DbSet<LoginViewModels> LoginViewModels { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SgtcodeModels> SgtcodeModels { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VHangHk> VHangHk { get; set; }
        public virtual DbSet<VSgtcode> VSgtcode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=118.68.170.128;database=EMD;Trusted_Connection=true;User Id=vanhong;Password=Hong@2019;Integrated security=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiNhanhs>(entity =>
            {
                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.DienThoai).HasMaxLength(20);

                entity.Property(e => e.MaChiNhanh)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DienGiaiModels>(entity =>
            {
                entity.Property(e => e.Giave)
                    .HasColumnName("giave")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Lephi)
                    .HasColumnName("lephi")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Nguoicapnhat)
                    .HasColumnName("nguoicapnhat")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nguoinhap)
                    .HasColumnName("nguoinhap")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phidv)
                    .HasColumnName("phidv")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sgtcode)
                    .HasColumnName("sgtcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Slve).HasColumnName("slve");

                entity.Property(e => e.Thuesb)
                    .HasColumnName("thuesb")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Thuevat)
                    .HasColumnName("thuevat")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<DmdaiLies>(entity =>
            {
                entity.ToTable("DMDaiLies");

                entity.HasIndex(e => e.ChiNhanhId);

                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.DienThoai).HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ChiNhanh)
                    .WithMany(p => p.DmdaiLies)
                    .HasForeignKey(d => d.ChiNhanhId);
            });

            modelBuilder.Entity<EmdcanTrus>(entity =>
            {
                entity.ToTable("EMDCanTrus");

                entity.Property(e => e.LoaiBk).HasColumnName("LoaiBK");

                entity.Property(e => e.NgaySua).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.StdatCoc)
                    .HasColumnName("STDatCoc")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.0))");
            });

            modelBuilder.Entity<Emds>(entity =>
            {
                entity.ToTable("EMDs");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CanTru)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.DaHoanCoc)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.HangHk)
                    .HasColumnName("HangHK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoaiBk)
                    .HasColumnName("LoaiBK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoaiTien)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayDc).HasColumnName("NgayDC");

                entity.Property(e => e.NgayXoa).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.NguoiNhap)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NguoiSua)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pnr)
                    .HasColumnName("PNR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sgtcode)
                    .HasColumnName("SGTCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SlveDaXuat).HasColumnName("SLVeDaXuat");

                entity.Property(e => e.SlveDatCoc).HasColumnName("SLVeDatCoc");

                entity.Property(e => e.SlveHoan)
                    .HasColumnName("SLVeHoan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoCtphat)
                    .HasColumnName("SoCTPhat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StdatCoc)
                    .HasColumnName("STDatCoc")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ThucTra)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TienPhat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TienXuatVe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tracking)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TyGia)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<HangHks>(entity =>
            {
                entity.ToTable("HangHKs");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<HoanVeModels>(entity =>
            {
                entity.Property(e => e.Giave)
                    .HasColumnName("giave")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Lephi)
                    .HasColumnName("lephi")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Nguoicapnhat)
                    .HasColumnName("nguoicapnhat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phidv)
                    .HasColumnName("phidv")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Phihoan)
                    .HasColumnName("phihoan")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sgtcode)
                    .HasColumnName("sgtcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Slve).HasColumnName("slve");

                entity.Property(e => e.Thuesb)
                    .HasColumnName("thuesb")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Thuevat)
                    .HasColumnName("thuevat")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<LoginViewModels>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SgtcodeModels>(entity =>
            {
                entity.ToTable("SGTCodeModels");

                entity.Property(e => e.Id).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Batdau).HasColumnName("batdau");

                entity.Property(e => e.Diemtq)
                    .HasColumnName("diemtq")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Ketthuc).HasColumnName("ketthuc");

                entity.Property(e => e.Sgtcode)
                    .HasColumnName("sgtcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sokhach).HasColumnName("sokhach");

                entity.Property(e => e.Tuyentq)
                    .HasColumnName("tuyentq")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.ChiNhanhId);

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.DmdaiLy)
                    .HasColumnName("DMDaiLy")
                    .HasMaxLength(50);

                entity.Property(e => e.Khoi).HasMaxLength(10);

                entity.Property(e => e.MaCn)
                    .HasColumnName("MaCN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgayTao).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.NguoiTao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhongBan).HasMaxLength(50);

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.ChiNhanh)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ChiNhanhId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<VHangHk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_HangHK");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<VSgtcode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_SGTCode");

                entity.Property(e => e.Batdau)
                    .HasColumnName("batdau")
                    .HasColumnType("datetime");

                entity.Property(e => e.Diemtq).HasColumnName("diemtq");

                entity.Property(e => e.Ketthuc)
                    .HasColumnName("ketthuc")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sgtcode)
                    .HasColumnName("sgtcode")
                    .IsUnicode(false);

                entity.Property(e => e.Sokhach).HasColumnName("sokhach");

                entity.Property(e => e.Tuyentq).HasColumnName("tuyentq");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

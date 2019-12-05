using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMD.Data.Models
{
    public class EMDTbl
    {
        public int Id { get; set; }

        [MaxLength(50), Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Code đoàn không được để trống")]
        public string SGTCode { get; set; }

        [DisplayName("Bắt Đầu")]
        [Required(ErrorMessage = "Ngày bắt đầu không được để trống")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BatDau { get; set; }

        [DisplayName("Kết Thúc")]
        [Required(ErrorMessage = "Ngày kết thúc không được để trống")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? KetThuc { get; set; }

        [DisplayName("SL Ve Đặt Cọc")]
        public int SLVeDatCoc { get; set; }

        [DisplayName("Ngày DC")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayDC { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Hết Han")]
        public DateTime? HetHan { get; set; }

        [MaxLength(150), Column(TypeName = "varchar(150)")]
        [DisplayName("Số EMD")]
        public string Number { get; set; }

        [DisplayName("Hãng HK")]
        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string HangHK { get; set; }

        [DisplayName("Số Tiền DC")]
        public decimal STDatCoc { get; set; }

        [DisplayName("Ngày Hoàn Cọc")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HoanCoc { get; set; }

        [DisplayName("Loại BooKing")]
        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string LoaiBK { get; set; }

        [DisplayName("SL Vé Đã Xuất")]
        public int SLVeDaXuat { get; set; }

        [DisplayName("Tiền Xuất Vé")]
        public decimal TienXuatVe { get; set; }

        [DisplayName("Tiền Phạt")]
        public decimal TienPhat { get; set; }

        [DisplayName("Ngày Phạt")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayPhat { get; set; }

        [DisplayName("Số CT Phạt")]
        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string SoCTPhat { get; set; }

        [DisplayName("Loại Tiền")]
        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string LoaiTien { get; set; }

        [DisplayName("Tỷ Giá")]
        public decimal TyGia { get; set; }

        [DisplayName("Ghi Chú")]
        [MaxLength(250), Column(TypeName = "varchar(250)")]
        public string GhiChu { get; set; }

        [DisplayName("Đóng Hồ Sơ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DongHoSo { get; set; }

        [DisplayName("Ngày Tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Create { get; set; }

        [DisplayName("Ngày Sửa")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySua { get; set; }

        [DisplayName("Người Nhập")]
        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string NguoiNhap { get; set; }

        [DisplayName("Lưu Vết")]
        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string Tracking { get; set; }

        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string PNR { get; set; }

        [DisplayName("Đã Hoàn Cọc")]
        public bool DaHoanCoc { get; set; }

        [DisplayName("Diễn Giải")]
        public string DienGiai { get; set; }
    }
}
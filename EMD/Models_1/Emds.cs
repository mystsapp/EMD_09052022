using System;
using System.Collections.Generic;

namespace EMD.Models_1
{
    public partial class Emds
    {
        public int Id { get; set; }
        public string Sgtcode { get; set; }
        public DateTime? BatDau { get; set; }
        public DateTime? KetThuc { get; set; }
        public int SlveDatCoc { get; set; }
        public DateTime? NgayDc { get; set; }
        public DateTime? HetHan { get; set; }
        public string Number { get; set; }
        public string HangHk { get; set; }
        public decimal StdatCoc { get; set; }
        public DateTime? HoanCoc { get; set; }
        public string LoaiBk { get; set; }
        public int SlveDaXuat { get; set; }
        public decimal? TienXuatVe { get; set; }
        public decimal TienPhat { get; set; }
        public DateTime? NgayPhat { get; set; }
        public string SoCtphat { get; set; }
        public string LoaiTien { get; set; }
        public decimal TyGia { get; set; }
        public string GhiChu { get; set; }
        public DateTime? DongHoSo { get; set; }
        public DateTime? Create { get; set; }
        public string NguoiNhap { get; set; }
        public string Tracking { get; set; }
        public string Pnr { get; set; }
        public bool? DaHoanCoc { get; set; }
        public string DienGiai { get; set; }
        public DateTime? NgaySua { get; set; }
        public string SlveHoan { get; set; }
        public string ThucTra { get; set; }
        public bool? CanTru { get; set; }
        public string NguoiSua { get; set; }
        public string LogFile { get; set; }
        public DateTime? NgayXoa { get; set; }
        public string UserXoa { get; set; }
        public bool Xoa { get; set; }
    }
}

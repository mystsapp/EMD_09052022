using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Models
{
    public class YeuCau
    {
        public int Id { get; set; }

        [Required, DisplayName("Số Yêu Cầu")]
        public int SoYeuCau { get; set; }

        [DisplayName("Ngày YC")]
        public DateTime NgayYC { get; set; }

        [Required, DisplayName("Số Vé")]
        public int SoVe { get; set; }

        [Required]
        [DisplayName("Hãng HK")]
        [MaxLength(50), Column(TypeName = "nvarchar(50)")]
        public string HangHK { get; set; }

        [Required]
        [MaxLength(50), Column(TypeName = "varchar")]
        public string SGTCode { get; set; }

        [DisplayName("Bắt Đầu")]
        [Required]
        public DateTime BatDau { get; set; }
        
        
        [DisplayName("Kết Thúc")]
        [Required]
        public DateTime KetThuc { get; set; }

        [DisplayName("Tuyến Tham Quan")]
        [MaxLength(200), Column(TypeName = "nvarchar(200)")]
        [Required]
        public string TuyenThamQuan { get; set; }

        [DisplayName("Nước Đến")]
        [MaxLength(100), Column(TypeName = "nvarchar(100)")]
        public string NuocDen { get; set; }
        
        [DisplayName("Thành Phố")]
        [MaxLength(100), Column(TypeName = "nvarchar(100)")]
        public string ThanhPho { get; set; }

        [DisplayName("Số Khách")]
        public int SoKhach { get; set; }

        [DisplayName("Ngày Chốt")]
        public DateTime? NgayChot { get; set; }

        [DisplayName("Hành Trình")]
        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string HanhTrinh { get; set; }

        [DisplayName("Số Khách Full")]
        public int SoKhachFull { get; set; }

        [DisplayName("Ngày Báo")]
        public DateTime? NgayBao { get; set; }

        [DisplayName("Người Báo")]
        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string NguoiBao { get; set; }

    }
}

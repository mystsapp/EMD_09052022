using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Models
{
    public class EMDCanTru
    {
        //public int Id { get; set; }
        //[DisplayName("EMD cấn trừ")]
        //[Required(ErrorMessage = "EMD Cấn trừ không được để trống.")]
        //public string Number { get; set; }

        //[DisplayName("EMD trước")]
        //public string OldNumber { get; set; }
        //public string LoaiBK { get; set; }
        //public bool TimThay { get; set; }

        //[DisplayName("Số tiền DC")]
        //public decimal STDatCoc { get; set; }

        //public string UserNhap { get; set; }
        //[DisplayName("Ngày cấn trừ")]
        //public DateTime NgayNhap { get; set; }
        //public string UserXoa { get; set; }
        //public DateTime NgayXoa { get; set; }
        //public string UserSua { get; set; }
        //public DateTime NgaySua { get; set; }

        public int Id { get; set; }
        [DisplayName("EMD cấn trừ")]
        [Required(ErrorMessage = "EMD Cấn trừ không được để trống.")]
        public string Number { get; set; }
        [DisplayName("EMD trước")]
        public string OldNumber { get; set; }
        public string LoaiBK { get; set; }
        public bool? TimThay { get; set; }
        public string UserNhap { get; set; }
        [DisplayName("Ngày cấn trừ")]
        public DateTime? NgayNhap { get; set; }
        public string UserXoa { get; set; }
        public DateTime? NgayXoa { get; set; }
        public DateTime? NgaySua { get; set; }
        public string UserSua { get; set; }
        [DisplayName("Số tiền DC")]
        public decimal? STDatCoc { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EMD.Models_1
{
    public partial class EmdcanTrus
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string OldNumber { get; set; }
        public string LoaiBk { get; set; }
        public bool? TimThay { get; set; }
        public string UserNhap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string UserXoa { get; set; }
        public DateTime? NgayXoa { get; set; }
        public DateTime? NgaySua { get; set; }
        public string UserSua { get; set; }
        public decimal? StdatCoc { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EMD.Models_1
{
    public partial class DmdaiLies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public int ChiNhanhId { get; set; }

        public virtual ChiNhanhs ChiNhanh { get; set; }
    }
}

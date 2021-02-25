using System;
using System.Collections.Generic;

namespace EMD.Models_1
{
    public partial class ChiNhanhs
    {
        public ChiNhanhs()
        {
            DmdaiLies = new HashSet<DmdaiLies>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string MaChiNhanh { get; set; }
        public string Name { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<DmdaiLies> DmdaiLies { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}

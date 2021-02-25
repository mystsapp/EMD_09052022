using System;
using System.Collections.Generic;

namespace EMD.Models_1
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhongBan { get; set; }
        public string Khoi { get; set; }
        public int ChiNhanhId { get; set; }
        public string DmdaiLy { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool? Doimk { get; set; }
        public DateTime? Ngaydoimk { get; set; }
        public string MaCn { get; set; }
        public string NguoiTao { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime NgayTao { get; set; }

        public virtual ChiNhanhs ChiNhanh { get; set; }
        public virtual Roles Role { get; set; }
    }
}

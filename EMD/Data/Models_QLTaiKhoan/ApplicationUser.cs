using System;
using System.Collections.Generic;

namespace EMD.Data.Models_QLTaiKhoan
{
    public partial class ApplicationUser
    {
        public string Username { get; set; }
        public string Mact { get; set; }

        public virtual Application MactNavigation { get; set; }
    }
}

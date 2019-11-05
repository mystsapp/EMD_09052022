using EMD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Models
{
    public class UserViewModel
    {
        public User User { get; set; }

        public IEnumerable<ChiNhanh> ChiNhanhs { get; set; }
        public IEnumerable<DMDaiLy> DMDaiLies { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}

using EMD.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Remote("UsersExists", "Users", ErrorMessage = "User đã tồn tại")]
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự.")]
        public string UsernameCreate { get; set; }

        
    }
}

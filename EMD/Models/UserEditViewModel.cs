using EMD.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Models
{
    public class UserEditViewModel
    {
        public User User { get; set; }

        public IEnumerable<ChiNhanh> ChiNhanhs { get; set; }
        public IEnumerable<DMDaiLy> DMDaiLies { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public string OldPass { get; set; }

        [Remote("UsersEditExists", "Users", AdditionalFields = "Username", ErrorMessage = "User đã tồn tại")]
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự.")]
        public string UsernameEdit { get; set; }
        public string Username { get; set; }
    }
}

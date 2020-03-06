﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Models
{
    public class changepassModel
    {
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập password cũ")]
        public string Password { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Vui lòng nhập password mới")]
        public string NewPassword { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Vui lòng nhập lại password mới")]
        [Compare("NewPassword", ErrorMessage = "The new passord and confirm password do not match.")]
        public string Confirmpassword { get; set; }

        public string strUrl { get; set; }
    }
}

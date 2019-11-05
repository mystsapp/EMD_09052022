using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Models
{
    public class changepassModel
    {
        [Display(Name = "Tên đăng nhập")]
        public string username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập password cũ")]
        public string password { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Vui lòng nhập password mới")]
        public string newpassword { get; set; }
        [Display(Name = "Mật khẩu mới")]

        [Required(ErrorMessage = "Vui lòng nhập lại password mới")]
        public string confirmpassword { get; set; }

        public string strUrl { get; set; }
    }
}

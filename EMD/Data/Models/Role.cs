using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Nhập Role")]
        [Remote("RolesExists", "Roles", ErrorMessage = "Role đã tồn tại")]
        public int Id { get; set; }

        [DisplayName("Role")]
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự."), Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public bool Trangthai { get; set; }
    }
}

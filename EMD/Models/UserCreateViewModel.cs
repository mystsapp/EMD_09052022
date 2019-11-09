﻿using EMD.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Models
{
    public class UserCreateViewModel
    {
        public IEnumerable<ChiNhanh> ChiNhanhs { get; set; }
        public IEnumerable<DMDaiLy> DMDaiLies { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự."), Column(TypeName = "nvarchar(50)")]
        [DisplayName("Họ Tên")]
        public string Name { get; set; }

        [DisplayName("Phòng Ban")]
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự."), Column(TypeName = "nvarchar(50)")]
        public string PhongBan { get; set; }

        [MaxLength(10, ErrorMessage = "Không vượt qua 50 ký tự."), Column(TypeName = "nvarchar(10)")]
        [DisplayName("Khối")]
        public string Khoi { get; set; }

        [DisplayName("Chi Nhánh")]
        public int ChiNhanhId { get; set; }

        [ForeignKey("ChiNhanhId")]
        public virtual ChiNhanh ChiNhanh { get; set; }

        [DisplayName("Đại Lý")]
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự."), Column(TypeName = "nvarchar(50)")]
        public string DMDaiLy { get; set; }

        [DisplayName("Tình Trạng")]
        public bool TinhTrang { get; set; }

        [Remote("UsersExists", "Users", ErrorMessage = "User đã tồn tại")]
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự."), Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }
        [MaxLength(50, ErrorMessage = "Không vượt qua 50 ký tự."), Column(TypeName = "varchar(50)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Role")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public bool? Doimk { get; set; }

        public DateTime? Ngaydoimk { get; set; }
    }
}

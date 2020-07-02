using EMD.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EMD.Models
{
    public class EMDViewModel
    {
        public IPagedList<EMDTbl> EMDTbls { get; set; }
        public EMDTbl EMDTbl { get; set; }
        public IEnumerable<HangHK> HangHKs { get; set; }

        [Remote("IsStringNameAvailable", "EMDs", ErrorMessage = "Số EMD này đã tồn tại")]
        [Required(ErrorMessage = "Số EMD không được để trống")]
        public string Number { get; set; }
        public string StrUrl { get; set; }
    }
}

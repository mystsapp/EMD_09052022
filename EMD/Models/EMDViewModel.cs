using EMD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Models
{
    public class EMDViewModel
    {
        public IEnumerable<EMDTbl> EMDTbls { get; set; }
        public EMDTbl EMDTbl { get; set; }
        public IEnumerable<HangHK> HangHKs { get; set; }
    }
}

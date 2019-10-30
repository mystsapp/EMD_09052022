using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Models
{
    public class SGTCodeModel
    {
        public decimal Id { get; set; }
        public string sgtcode { get; set; }
        public DateTime batdau { get; set; }
        public DateTime ketthuc { get; set; }
        public string diemtq { get; set; }
        public string tuyentq { get; set; }
        public int sokhach { get; set; }
    }
}

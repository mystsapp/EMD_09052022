using System;
using System.Collections.Generic;

namespace EMD.Models_1
{
    public partial class SgtcodeModels
    {
        public decimal Id { get; set; }
        public string Sgtcode { get; set; }
        public DateTime Batdau { get; set; }
        public DateTime Ketthuc { get; set; }
        public string Diemtq { get; set; }
        public string Tuyentq { get; set; }
        public int Sokhach { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMD.Data.Models
{
    public class SGTCodeModel
    {
        public decimal Id { get; set; }

        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string sgtcode { get; set; }

        public DateTime batdau { get; set; }
        public DateTime ketthuc { get; set; }

        [MaxLength(250), Column(TypeName = "varchar(250)")]
        public string diemtq { get; set; }

        [MaxLength(250), Column(TypeName = "varchar(250)")]
        public string tuyentq { get; set; }

        public int sokhach { get; set; }



       
    }
}
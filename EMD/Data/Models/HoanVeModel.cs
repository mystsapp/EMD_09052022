using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Models
{
    public class HoanVeModel
    {
        public int Id { get; set; }

        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string sgtcode { get; set; }
        public int slve { get; set; }

        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string number { get; set; }
        public decimal giave { get; set; }
        public decimal thuesb { get; set; }
        public decimal lephi { get; set; }
        public decimal thuevat { get; set; }
        public decimal phidv { get; set; }
        public decimal phihoan { get; set; }

        
        [MaxLength(50), Column(TypeName = "varchar(50)")]
        public string nguoicapnhat { get; set; }

    }
}

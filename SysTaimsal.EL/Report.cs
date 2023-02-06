using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace SysTaimsal.EL
{
    [Table("Report")]
    public partial class Report
    {
    
        [Key]
        public int IdReport { get; set; }
        public int IdClient { get; set; }
        public int? IdProduct { get; set; }
        public int? IdProvider { get; set; }
        public int? IdMachine { get; set; }
        public int? IdUser { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        
        [ForeignKey("IdUser")]
        public virtual UserDev? user { get; set; }
        
        [ForeignKey("IdClient")]
        public virtual Client? Client { get; set; }

        [ForeignKey("IdProduct")]
        public virtual Product? Product{ get; set; } 

        [ForeignKey("IdProvider")]
        public virtual Provider? Provider{ get; set; }
        [ForeignKey("IdMachine")]
        public virtual Machine? Machine{ get; set; }

    }
}

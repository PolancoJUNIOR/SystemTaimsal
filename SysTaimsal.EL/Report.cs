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
        //public Report()
        //{
        //    users = new HashSet<User>();
        //    Clients = new HashSet<Client>();
        //    Products = new HashSet<Product>();
        //    Providers = new HashSet<Provider>();
        //}

        [Key]
        public int IdReport { get; set; }


        public int IdClient { get; set; }
        //[ForeignKey("IdProduct")]
        public int? IdProduct { get; set; }
        //[ForeignKey("IdProvider")]
        public int? IdProvider { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        [ForeignKey("Id")]
        public virtual User user { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }

        [ForeignKey("IdProduct")]
        public virtual Product Product{ get; set; } 

        [ForeignKey("IdProvider")]
        public virtual Provider Provider{ get; set; }


        //[InverseProperty("Product")]
        //public virtual ICollection<Product>? IdProductNavigation { get; set; }


        //[InverseProperty("Provider")]
        //public virtual ICollection<Provider>? IdProviderNavigation { get; set; }

        //public virtual ICollection<Machine>? IdMachineNavigation { get; set; }
    }
}

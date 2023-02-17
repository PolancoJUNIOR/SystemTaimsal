using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Reports = new HashSet<Report>();
        }

        [Key]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        [Display(Name = "Producto")]
        public string NameProduct { get; set; }
        public string? DescriptionProduct { get; set; }
        [Required(ErrorMessage = "Precio es obligatorio")]
        [Display(Name = "Precio")]
        public decimal? Price { get; set; }
        public string? ImageProduct { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        [ForeignKey("IdReport")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}

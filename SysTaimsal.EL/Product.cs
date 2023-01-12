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
   
        [Key]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        [Display(Name = "Producto")]
        public string NameProduct { get; set; }
        [Required(ErrorMessage = "Imagen necesaria")]
        public string ImageProduct { get; set; }
        [StringLength(500, ErrorMessage = "Maximo 500 caracteres")]
        public string? DescriptionProduct { get; set; }
        [Required(ErrorMessage = "Precio es obligatorio")]
        [Display(Name = "Precio")]
        public decimal? Price { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        [ForeignKey("IdReport")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}

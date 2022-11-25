using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    public  class Provider
    {
        [Key]
        public int IdProvider { get; set; }
        [ForeignKey("Machine")]
        [Required(ErrorMessage = "Machine es obligatorio")]
        [Display(Name = "Machine")]
        public int? IdMachine { get; set; }
        [Required(ErrorMessage ="Nombre es obligatorio")]
        [StringLength(40, ErrorMessage ="Maximo 40 caracteres")]
        [Display(Name = "Nombre de producto")]
        public string? NameProvider { get; set; }
    }
}

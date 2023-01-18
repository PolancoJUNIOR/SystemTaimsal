using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    [Table("Machine")]
    public class Machine
    {
        
        [Key]
        public int IdMachine { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string NameMachine { get; set; }
        public string? ImageMachine { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        [ForeignKey("IdProvider")]
        public virtual ICollection<Provider>Providers{ get; set; }
    }
}


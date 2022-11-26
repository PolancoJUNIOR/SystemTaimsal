using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    public class Machine
    {
        public Machine()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        public int IdMachine { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string NameMachine { get; set; }
        public string? ImageMachine { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}


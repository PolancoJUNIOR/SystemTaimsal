using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public int? IdMachine { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string NameEmployee { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string LastNameEmployee { get; set; }
        [StringLength (30, ErrorMessage ="Maximo 30 caracteres")]
        public string? Rol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        public string FullName()
        {
            string NameF = NameEmployee + " " + LastNameEmployee;
            return NameF;
        }

        public virtual Machine? IdMachineNavigation { get; set; }
    }
}

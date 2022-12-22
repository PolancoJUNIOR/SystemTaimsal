using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    public partial class Rol
    {
        public Rol(){
            users = new HashSet<User>();
        }
        [Key]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string NameRol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}

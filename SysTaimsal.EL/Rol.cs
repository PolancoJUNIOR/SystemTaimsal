using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysTaimsal.EL
{
    [Table("Rol")]
    public partial class Rol
    {
        public Rol() {
            users = new HashSet<UserDev>();
        }

        [Key]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string NameRol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        [ForeignKey("Id")]
        public virtual ICollection<UserDev> users { get; set; }
    }
}
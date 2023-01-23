using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SysTaimsal.EL
{
    [Table("User")]
    public class User
    {
      
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol es obligatorio")]
        public int? IdRol { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string NameUser { get; set; }
        
        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string LastNameUser { get; set; }
        
        [Required(ErrorMessage = "Login es obligatorio")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Password es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Status_User { get; set; }
        
        [Display(Name = "Fecha registro")]
        public DateTime RegistrationUser { get; set; }
        [ForeignKey("IdRol")]
        public virtual Rol? Rol { get; set; }

        [ForeignKey("IdReport")]
        public virtual ICollection<Report> Reports { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        
        [NotMapped]
        [Required(ErrorMessage = "Confirmar el password")]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y confirmar password deben de ser iguales")]
        [Display(Name = "Confirmar password")]
        public string ConfirmPassword_aux { get; set; }
    }
    public enum Status_User
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

    
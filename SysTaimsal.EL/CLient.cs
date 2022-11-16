using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string NameClient { get; set; }
        [Required(ErrorMessage = "Numero obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public int PhoneNumber { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysTaimsal.EL
{
    [Table("Client")]
    public partial class Client
    {
        public Client()
        {
            Reports = new HashSet<Report>();
        }

        [Key]
        public int IdClient { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        [Display(Name = "Nombre de Cliente")]
        public string NameClient { get; set; }
        [Required(ErrorMessage = "Numero obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        [ForeignKey("IdReport")]
        public virtual ICollection<Report> Reports { get; set; }

    }
}

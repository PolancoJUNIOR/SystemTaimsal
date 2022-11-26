using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.EL
{
    public class Attendance
    {
        [Key]
        public int IdAttendance { get; set; }
        [ForeignKey("Employee")]
        [Required(ErrorMessage = "Empleado es necesario")]
        [Display(Name = "Employee")]
        public int IdEmployee { get; set; }
        public DateTime? DayAttendence { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public virtual Employee? IdEmployeeNavigation { get; set; }
    }
}

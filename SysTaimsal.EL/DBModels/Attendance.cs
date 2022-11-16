using System;
using System.Collections.Generic;

namespace SysTaimsal.EL.DBModels
{
    public partial class Attendance
    {
        public int IdAttendance { get; set; }
        public int IdEmployee { get; set; }
        public DateTime? DayAttendence { get; set; }
        public TimeSpan? CheckInTime { get; set; }
    }
}

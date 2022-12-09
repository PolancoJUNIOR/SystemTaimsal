using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class AttendanceBL
    {
        public async Task<int> CreateAsync(Attendance pAttendance)
        {
            return await AttendanceDAL.CreateAsync(pAttendance);
        }

        public async Task<int> ModifyAsync(Attendance pAttendance) {
            return await AttendanceDAL.ModifyAsync(pAttendance);
        }

        public async Task<Attendance> GetByIdAsync(Attendance pAttendance)
        {
            return await AttendanceDAL.GetByIdAsync(pAttendance);
        }

        public async Task<List<Attendance>> GetAllAsync() { 
            return await AttendanceDAL.GetAllAsync();   
        }

        public async Task<List<Attendance>> SearchAsync(Attendance pAttendance) {
            return await AttendanceDAL.SearchAsync(pAttendance);
        }

        public async Task<int> DeleteAsync(Attendance pAttendance) {
            return await AttendanceDAL.DeleteAsync(pAttendance);
        }
    }
}

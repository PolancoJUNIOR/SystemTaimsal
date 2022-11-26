using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.DAL
{
    public class AttendanceDAL
    {

        public static async Task<int> CreateAsync(Attendance pAttendance)
        {
            int result = 0;
            using (var DBContext = new SysTaimsalBDContext())
            {
                DBContext.Add(pAttendance);
                result = await DBContext.SaveChangesAsync();
            }
            return result;

        }

        public static async Task<int> ModifyAsync(Attendance pAttendance)
        {
            int result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                var attendance = await DbContext.Attendances.FirstOrDefaultAsync(s => s.IdAttendance == pAttendance.IdAttendance);
                attendance.IdEmployee = pAttendance.IdEmployee;
                attendance.DayAttendence = pAttendance.DayAttendence;
                attendance.CheckInTime = attendance.CheckInTime;
                DbContext.Update(attendance);
                result = await DbContext.SaveChangesAsync();

            }
            return result;
        }

        public static async Task<Attendance> GetByIdAsync(Attendance pAttendance)
        {
            var attendance = new Attendance();
            using (var dbContext = new SysTaimsalBDContext())
            {
                attendance = await dbContext.Attendances.FirstOrDefaultAsync(s => s.IdAttendance == pAttendance.IdAttendance);

            }
            return attendance;
        }

        public static async Task<List<Attendance>> GetAllAsync()
        {
            var attendance = new List<Attendance>();
            using (var dbContext = new SysTaimsalBDContext())
            {
                attendance = await dbContext.Attendances.ToListAsync();
            }
            return attendance;
        }

        internal static IQueryable<Attendance> QuerySelect(IQueryable<Attendance> pQuery, Attendance pAttendance)
        {

            if (pAttendance.IdAttendance > 0)
                pQuery = pQuery.Where(s => s.IdAttendance == pAttendance.IdAttendance);
            if (pAttendance.IdEmployee> 0)
                pQuery = pQuery.Where(s => s.IdEmployee == pAttendance.IdEmployee);
            if (pAttendance.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pAttendance.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public static async Task<List<Attendance>> SearchAsync(Attendance pAttendance)
        {
            var attendances = new List<Attendance>();

            using (var dbContext = new SysTaimsalBDContext())
            {
                var select = dbContext.Attendances.AsQueryable();
                select = QuerySelect(select, pAttendance);
                attendances = await select.ToListAsync();
            }
            return attendances;
        }

        public static async Task<int> DeleteAsync(Attendance pAttendance)
        {
            int result = 0;
            using (var dbContext = new SysTaimsalBDContext())
            {
                var attendance = await dbContext.Attendances.FirstOrDefaultAsync(s => s.IdAttendance == pAttendance.IdAttendance);
                dbContext.Attendances.Remove(attendance);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}

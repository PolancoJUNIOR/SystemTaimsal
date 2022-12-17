using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;

namespace SysTaimsal.DAL
{
    public class EmployeeDAL
    {

        public static async Task<int> CreateAsync(Employee pEmployee)
        {
            int result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                DbContext.Add(pEmployee);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModifyAsync(Employee pEmployee)
        {
            var result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                var employee = await DbContext.Employees.FirstOrDefaultAsync(s => s.IdEmployee == pEmployee.IdEmployee);
                employee.IdMachine = pEmployee.IdMachine;
                employee.NameEmployee = pEmployee.NameEmployee;
                employee.LastNameEmployee = pEmployee.LastNameEmployee;
                DbContext.Update(employee);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Employee> GetByIdAsync(Employee pEmployee)
        {
            var employee = new Employee();
            using (var dbContext = new SysTaimsalBDContext())
            {
                employee = await dbContext.Employees.FirstOrDefaultAsync(s => s.IdEmployee == pEmployee.IdEmployee);

            }
            return employee;
        }

        public static async Task<List<Employee>> GetAllAsync()
        {
            var employee = new List<Employee>();
            using (var dbContext = new SysTaimsalBDContext())
            {
                employee = await dbContext.Employees.ToListAsync();
            }
            return employee;
        }

        internal static IQueryable<Employee> QuerySelect(IQueryable<Employee> pQuery, Employee pEmployee)
        {

            if (pEmployee.IdEmployee > 0)
                pQuery = pQuery.Where(s => s.IdEmployee == pEmployee.IdEmployee);
            if (pEmployee.IdMachine > 0)
                pQuery = pQuery.Where(s => s.IdEmployee == pEmployee.IdEmployee);
            if (!string.IsNullOrWhiteSpace(pEmployee.NameEmployee))
                pQuery = pQuery.Where(s => s.NameEmployee.Contains(pEmployee.NameEmployee));
            if (!string.IsNullOrWhiteSpace(pEmployee.LastNameEmployee))
                pQuery = pQuery.Where(s => s.LastNameEmployee.Contains(pEmployee.LastNameEmployee));
            if (pEmployee.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pEmployee.Top_Aux).AsQueryable();
            }
            pQuery = pQuery.OrderByDescending(s => s.IdEmployee).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Employee>> SearchAsync(Employee pEmployee)
        {
            var Employees = new List<Employee>();

            using (var dbContext = new SysTaimsalBDContext())
            {
                var select = dbContext.Employees.AsQueryable();
                select = QuerySelect(select, pEmployee);
                Employees = await select.ToListAsync();
            }
            return Employees;
        }

        public static async Task<int> DeleteAsync(Employee pEmployee)
        {
            int result = 0;
            using (var dbContext = new SysTaimsalBDContext())
            {
                var Employee = await dbContext.Employees.FirstOrDefaultAsync(s => s.IdEmployee == pEmployee.IdEmployee);
                dbContext.Employees.Remove(Employee);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}

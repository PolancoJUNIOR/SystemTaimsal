using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class EmployeeBL
    {
        public async Task<int> CreateAsync(Employee pEmployee)
        {
            return await EmployeeDAL.CreateAsync(pEmployee);
        }

        public async Task<int> ModifyAsync(Employee pEmployee)
        {
            return await EmployeeDAL.ModifyAsync(pEmployee);
        }

        public async Task<Employee> GetByIdAsync(Employee pEmployee)
        {
            return await EmployeeDAL.GetByIdAsync(pEmployee);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await EmployeeDAL.GetAllAsync();
        }

        public async Task<List<Employee>> SearchAsync(Employee pEmployee)
        {
            return await EmployeeDAL.SearchAsync(pEmployee);
        }

        public async Task<int> DeleteAsync(Employee pEmployee)
        {
            return await EmployeeDAL.DeleteAsync(pEmployee);
        }
    }
}

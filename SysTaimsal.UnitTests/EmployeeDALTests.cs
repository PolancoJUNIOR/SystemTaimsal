using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysTaimsal.DAL;
using SysTaimsal.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.DAL.Tests
{
    [TestClass()]
    public class EmployeeDALTests
    {
        private static Employee EmployeeInitial = new Employee { IdEmployee = 1, IdMachine = 1, NameEmployee = "Juanito", LastNameEmployee = "Perez"};
        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var Employee = new Employee();
            Employee.IdEmployee = EmployeeInitial.IdEmployee;
            Employee.NameEmployee = EmployeeInitial.NameEmployee;
            Employee.LastNameEmployee = EmployeeInitial.LastNameEmployee;
            int result = await EmployeeDAL.CreateAsync(Employee);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var Employee = new Employee();
            Employee.IdEmployee = EmployeeInitial.IdEmployee;
            Employee.NameEmployee = "Roberto";
            var result = await EmployeeDAL.ModifyAsync(Employee);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var Employee = new Employee();
            Employee.IdMachine = EmployeeInitial.IdEmployee;
            var result = await EmployeeDAL.GetByIdAsync(Employee);
            Assert.AreEqual(Employee.IdEmployee, result.IdEmployee);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var resutl = await EmployeeDAL.GetAllAsync();
            Assert.AreNotEqual(0, resutl.Count);
        }

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var Employee = new Employee();
            Employee.IdEmployee = EmployeeInitial.IdEmployee;
            var result = await EmployeeDAL.SearchAsync(Employee);
            Assert.AreNotEqual(0, result.Count);

        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var Employee = new Employee();
            Employee.IdEmployee = EmployeeInitial.IdEmployee;
            int result = await EmployeeDAL.DeleteAsync(Employee);
            Assert.AreNotEqual(0, result);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysTaimsal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SysTaimsal.EL;

namespace SysTaimsal.DAL.Tests
{
    [TestClass()]
    public class RolDALTests
    {
        private static Rol rolInitial = new Rol { Id = 1 };

        [TestMethod()]
        public async void T1CrearteAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInitial.Id;
            rol.NameRol = "Administrador";
            int result = await RolDAL.CrearteAsync(rol);
            Assert.AreNotEqual(0, result);
            rolInitial.Id = rol.Id;
        }

        [TestMethod()]
        public async void T2ModifyAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInitial.Id;
            rol.NameRol = "Admin";
            int result = await RolDAL.ModifyAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async void T3GetByIdAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInitial.Id;
            var result = await RolDAL.GetByIdAsync(rol);
            Assert.AreEqual(rol.Id, result.Id);
        }

        [TestMethod()]
        public async void T4GetAllAsyncTest()
        {
            var result = await RolDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async void T5SearchAsyncTest()
        {
            var rol = new Rol();
            rol.NameRol = "1";
            rol.Top_Aux = 10;
            var result = await RolDAL.SearchAsync(rol);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async void T6DeleteAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInitial.Id;
            int result = await RolDAL.DeleteAsync(rol);
            Assert.AreNotEqual(0, result);
        }
    }
}
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
    public class UserDevDALTests
    {
        private static UserDev UserDevInicial = new UserDev { IdUser = 7, IdRol = 2, Login = "JuanUser", Password = "12345" };
        [TestMethod()]
        public async Task  CrearAsyncTest()
        {
            var UserDev = new UserDev();
            UserDev.IdRol = UserDevInicial.IdRol;
            UserDev.NameUser = "juan";
            UserDev.LastNameUser = "lopez";
            UserDev.Login = "juanUser1";
            string password = "12345";
            UserDev.Password = password;
            UserDev.Status_User = (byte)Status_Users.INACTIVO;
            int result = await UserDevDAL.CrearAsync(UserDev);
            Assert.AreNotEqual(0, result);
            UserDevInicial.IdUser = UserDev.IdUser;
            UserDevInicial.Password = password;
            UserDevInicial.Login = UserDev.Login;
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            var UserDev = new UserDev();
            UserDev.IdUser = UserDevInicial.IdUser;
            UserDev.IdRol = UserDevInicial.IdRol;
            UserDev.NameUser = "Juan";
            UserDev.LastNameUser = "Lopez";
            UserDev.Login = "JuanUser01";
            UserDev.Status_User = (byte)Status_Users.ACTIVO;
            int result = await UserDevDAL.ModificarAsync(UserDev);
            Assert.AreNotEqual(0, result);
            UserDevInicial.Login = UserDev.Login;
        }

        [TestMethod()]
        public async Task  ObtenerPorIdAsyncTest()
        {
            var UserDev = new UserDev();
            UserDev.IdUser = UserDevInicial.IdUser;
            var resultUserDev = await UserDevDAL.ObtenerPorIdAsync(UserDev);
            Assert.AreEqual(UserDev.IdUser, resultUserDev.IdUser);
        }

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            var resultUserDevs = await UserDevDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultUserDevs.Count);
        }

        [TestMethod()]
        public async Task  BuscarAsyncTest()
        {

            var UserDev = new UserDev();
            UserDev.IdRol = UserDevInicial.IdRol;
            UserDev.NameUser  = "A";
            UserDev.LastNameUser= "a";
            UserDev.Login = "A";
            UserDev.Status_User = (byte)Status_Users.ACTIVO;
            UserDev.Top_Aux = 10;
            var resultUserDevs = await UserDevDAL.BuscarAsync(UserDev);
            Assert.AreNotEqual(0, resultUserDevs.Count);
        }

        [TestMethod()]
        public async Task CambiarPasswordAsyncTest()
        {
            var UserDev = new UserDev();
            UserDev.IdUser = UserDevInicial.IdUser;
            string passwordNuevo = "123456";
            UserDev.Password = passwordNuevo;
            var result = await UserDevDAL.CambiarPasswordAsync(UserDev, UserDevInicial.Password);
            Assert.AreNotEqual(0, result);
            UserDevInicial.Password = passwordNuevo;
        }
        [TestMethod()]
        public async Task LoginAsyncTest()
        {
            var UserDev = new UserDev();
            UserDev.Login = UserDevInicial.Login;
            UserDev.Password = UserDevInicial.Password;
            var resultUserDev = await UserDevDAL.LoginAsync(UserDev);
            Assert.AreEqual(UserDev.Login, resultUserDev.Login);
        }


        [TestMethod()]
        public async Task EliminarAsyncTest()
        {

            var UserDev = new UserDev();
            UserDev.IdUser = UserDevInicial.IdUser;
            int result = await UserDevDAL.EliminarAsync(UserDev);
            Assert.AreNotEqual(0, result);
        }
    }
}
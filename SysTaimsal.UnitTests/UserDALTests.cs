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
    public class UserDALTests
    {
        private static User UserInitial = new User { Id = 1, IdRol = 1, Login = "RonaldUser", Password = "12345" };
        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var User = new User();
            User.IdRol = UserInitial.IdRol;
            User.NameUser = "Ronald";
            User.LastName = "Mejia";
            User.Login = "RonaldUser";
            string password = "12345";
            User.Password = password;
            User.StatusUser = (byte)Status_User.INACTIVO;
            int resutl = await UserDAL.CreateAsync(User);
            Assert.AreNotEqual(0, resutl);
            UserInitial.Id = User.Id;
            UserInitial.Password = password;
            UserInitial.Login = User.Login;
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var user = new User();
            user.Id = UserInitial.Id;
            user.IdRol = UserInitial.IdRol;
            user.NameUser = "Ronald";
            user.LastName = "Mejia";
            user.StatusUser = (byte)Status_User.ACTIVO;
            int result  = await UserDAL.ModifyAsync(user);
            Assert.AreNotEqual(0, result);
            UserInitial.Login = user.Login;
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var user = new User();
            user.Id = UserInitial.Id;
            var resulUser = await UserDAL.GetByIdAsync(user);
            Assert.AreEqual(user.Id, resulUser.Id);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var resultUser = await UserDAL.GetAllAsync();
            Assert.AreNotEqual(0, resultUser.Count);
        } 

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var user = new User();
            user.IdRol = UserInitial.IdRol;
            user.NameUser = "A";
            user.LastName = "a";
            user.Login = "A";
            user.StatusUser = (byte)Status_User.ACTIVO;
            user.Top_Aux = 10;
            var resultUser = await UserDAL.SearchAsync(user);
            Assert.AreNotEqual(0, resultUser.Count);
        }
        [TestMethod()]
        public async Task T6SearchIncludeRolesAsyncTest()
        {
            var user = new User();
            user.IdRol = UserInitial.IdRol;
            user.NameUser = "A";
            user.LastName = "a";
            user.Login = "A";
            user.StatusUser = (byte)Status_User.ACTIVO;
            user.Top_Aux = 10;
            var result = await UserDAL.SearchIncludeRolesAsync(user);
            Assert.AreNotEqual(0, result.Count);
            var lastUser = result.FirstOrDefault();
            Assert.IsTrue(lastUser.Rol != null && user.IdRol == lastUser.Rol.IdRol);
        }

        [TestMethod()]
        public async Task T7ChangePasswordAsyncTest()
        {
            var user = new User();
            user.Id = UserInitial.Id;
            string newPassword = "123456";
            user.Password = newPassword;
            var result = await UserDAL.ChangePasswordAsync(user, UserInitial.Password);
            Assert.AreNotEqual(0, result);
            UserInitial.Password = newPassword;
        }


        [TestMethod()]
        public async Task T8LoginAsyncTest()
        {
            var user = new User();
            user.Id = UserInitial.Id;
            user.Password = UserInitial.Password;
            var resultuser = await UserDAL.LoginAsync(user);
            Assert.AreEqual(user.Login, resultuser.Login);
        }
            
        [TestMethod()]
        public async Task T9DeleteAsyncTest()
        {
            var user = new User();
            user.Id = UserInitial.Id;
            int result = await UserDAL.DeleteAsync(user);
            Assert.AreNotEqual(0, result);
        }
    }
}
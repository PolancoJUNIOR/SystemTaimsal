using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;

namespace SysTaimsal.DAL
{
    public class UserDAL
    {

        private static void EncriptarMD5(User pUser)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pUser.Password));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUser.Password = strEncriptar;
            }
        }
        private static async Task<bool> ExistLogin(User pUser, SysTaimsalBDContext pDbContext)
        {
            bool result = false;
            var loginUserExiste = await pDbContext.User.FirstOrDefaultAsync(s => s.Login == pUser.Login && s.Id != pUser.Id);
            if (loginUserExiste != null && loginUserExiste.Id > 0 && loginUserExiste.Login == pUser.Login)
                result = true;
            return result;
        }

        #region CRUD
        public static async Task<int> CreateAsync(User pUser)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                bool existeLogin = await ExistLogin(pUser, BDContext);
                if (existeLogin == false)
                {

                    pUser.RegistrationUser = DateTime.Now;
                    EncriptarMD5(pUser);
                    BDContext.Add(pUser);
                    result = await BDContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }
     
        
        public static async Task<int> ModifyAsync(User pUser)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                bool existeLogin = await ExistLogin(pUser, BDContext);
                if (existeLogin == false)
                {
                    var user = await BDContext.User.FirstOrDefaultAsync(s => s.Id == pUser.Id);
                    user.IdRol = pUser.IdRol;
                    user.NameUser = pUser.NameUser;
                    user.LastNameUser = pUser.LastNameUser;
                    user.Login = pUser.Login;
                    user.Status_User = pUser.Status_User;
                    BDContext.Update(user);
                    result = await BDContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }
        public static async Task<int> DeleteAsync(User pUser)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                var User = await BDContext.User.FirstOrDefaultAsync(s => s.Id == pUser.Id);
                BDContext.User.Remove(User);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<User> GetByIdAsync(User pUser)
        {
            var User = new User();
            using (var BDContext = new SysTaimsalBDContext())
            {
                User = await BDContext.User.FirstOrDefaultAsync(s => s.Id == pUser.Id);
            }
            return User;
        }
        public static async Task<List<User>> GetAllAsync()
        {
            var Users = new List<User>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                Users = await BDContext.User.ToListAsync();
            }
            return Users;
        }
        internal static IQueryable<User> QuerySelect(IQueryable<User> pQuery, User pUser)
        {
            if (pUser.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pUser.Id);
            if (pUser.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pUser.IdRol);
            //if (pUser.IdReport > 0)
            //    pQuery = pQuery.Where(s => s.IdReport == pUser.IdReport);
            if (!string.IsNullOrWhiteSpace(pUser.NameUser))
                pQuery = pQuery.Where(s => s.NameUser.Contains(pUser.NameUser));
            if (!string.IsNullOrWhiteSpace(pUser.LastNameUser))
                pQuery = pQuery.Where(s => s.LastNameUser.Contains(pUser.LastNameUser));
            if (!string.IsNullOrWhiteSpace(pUser.Login))
                pQuery = pQuery.Where(s => s.Login.Contains(pUser.Login));
            if (pUser.Status_User > 0)
                pQuery = pQuery.Where(s => s.Status_User== pUser.Status_User);
            if (pUser.RegistrationUser.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pUser.RegistrationUser.Year, pUser.RegistrationUser.Month, pUser.RegistrationUser.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.RegistrationUser >= fechaInicial && s.RegistrationUser<= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pUser.Top_Aux > 0)
                pQuery = pQuery.Take(pUser.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<User>> SearchAsync(User pUser)
        {
            var Users = new List<User>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                var select = BDContext.User.AsQueryable();
                select = QuerySelect(select, pUser);
                Users = await select.ToListAsync();
            }
            return Users;
        }
        #endregion
        public static async Task<List<User>> SearchIncludeRolesAsync(User pUser)
        {
            var Users = new List<User>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                var select = BDContext.User.AsQueryable();
                select = QuerySelect(select, pUser).Include(s => s.IdRol).AsQueryable();
                Users = await select.ToListAsync();
            }
            return Users;
        }
        public static async Task<User> LoginAsync(User pUser)
        {
            var User = new User();
            using (var BDContext = new SysTaimsalBDContext())
            {
                EncriptarMD5(pUser);
                User = await BDContext.User.FirstOrDefaultAsync(s => s.Login == pUser.Login &&
                s.Password == pUser.Password && s.Status_User== (byte)Status_User.ACTIVO);
            }
            return User;
        }
        public static async Task<int> ChangePasswordAsync(User pUser, string pPasswordAnt)
        {
            int result = 0;
            var UserPassAnt = new User { Password = pPasswordAnt };
            EncriptarMD5(UserPassAnt);
            using (var BDContext = new SysTaimsalBDContext())
            {
                var User = await BDContext.User.FirstOrDefaultAsync(s => s.Id == pUser.Id);
                if (UserPassAnt.Password == User.Password)
                {
                    EncriptarMD5(pUser);
                    User.Password = pUser.Password;
                    BDContext.Update(User);
                    result = await BDContext.SaveChangesAsync();
                }
                else
                    throw new Exception("El password actual es incorrecto");
            }
            return result;
        }
    }
}

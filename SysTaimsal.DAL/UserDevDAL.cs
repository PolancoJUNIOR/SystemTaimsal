﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*****************************
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using SysTaimsal.EL;

namespace SysTaimsal.DAL
{
    public class UserDevDAL
    {
        public static void EncryotMD5(UserDev pUserDev)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pUserDev.Password));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUserDev.Password = strEncriptar;
            }
            //using (var md5 = new MD5CryptoServiceProvider())
            //{
            //    var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pUserDev.Password));
            //    var strEncriptar = BitConverter.ToString(result).Replace("-", "").ToLower();
            //    pUserDev.Password = strEncriptar;
            //}
        }

        public static void EncryptSHA256(UserDev pUserDev)
        {
            using (var sha256 = new SHA256Managed())
            {
                var result = sha256.ComputeHash(Encoding.ASCII.GetBytes(pUserDev.Password));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUserDev.Password = strEncriptar;
            }
        }

        private static async Task<bool> ExistLogin(UserDev pUserDev, SysTaimsalBDContext pDbContext)
        {
            return await pDbContext.UserDevs
                .Where(s => s.Login == pUserDev.Login && s.IdUser != pUserDev.IdUser)
                .AnyAsync();
        }



        #region CRUD
        public static async Task<int> CrearAsync(UserDev pUsuario)
        {
            int result = 0;
            using (var bdContexto = new SysTaimsalBDContext())
            {
                bool ExisteLogin = await ExistLogin(pUsuario, bdContexto);
                if (ExisteLogin == false)
                {
                    pUsuario.RegistrationUser = DateTime.Now;
                    EncryotMD5(pUsuario);
                    bdContexto.Add(pUsuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }
        public static async Task<int> ModificarAsync(UserDev pUsuario)
        {
            int result = 0;
            using (var bdContexto = new SysTaimsalBDContext())
            {
                bool existeLogin = await ExistLogin(pUsuario, bdContexto);
                if (existeLogin == false)
                {
                    var usuario = await bdContexto.UserDevs.FirstOrDefaultAsync(s => s.IdUser == pUsuario.IdUser);
                    usuario.IdRol = pUsuario.IdRol;
                    usuario.NameUser = pUsuario.NameUser;
                    usuario.LastNameUser = pUsuario.LastNameUser;
                    usuario.Login = pUsuario.Login;
                    usuario.Status_User = pUsuario.Status_User;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("Login ya existe");
            }
            return result;
        }
        public static async Task<int> EliminarAsync(UserDev pUsuario)
        {
            int result = 0;
            using (var bdContexto = new SysTaimsalBDContext())
            {
                var usuario = await bdContexto.UserDevs.FirstOrDefaultAsync(s => s.IdUser == pUsuario.IdUser);
                bdContexto.UserDevs.Remove(usuario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<UserDev> ObtenerPorIdAsync(UserDev pUsuario)
        {
            var usuario = new UserDev();
            using (var bdContexto = new SysTaimsalBDContext())
            {
                usuario = await bdContexto.UserDevs.FirstOrDefaultAsync(s => s.IdUser == pUsuario.IdUser);
            }
            return usuario;
        }
        public static async Task<List<UserDev>> ObtenerTodosAsync()
        {
            var usuarios = new List<UserDev>();
            using (var bdContexto = new SysTaimsalBDContext())
            {
                usuarios = await bdContexto.UserDevs.ToListAsync();
            }
            return usuarios;
        }
        internal static IQueryable<UserDev> QuerySelect(IQueryable<UserDev> pQuery, UserDev pUsuario)
        {
            if (pUsuario.IdUser > 0)
                pQuery = pQuery.Where(s => s.IdUser == pUsuario.IdUser);
            if (pUsuario.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pUsuario.IdRol);
            if (!string.IsNullOrWhiteSpace(pUsuario.NameUser))
                pQuery = pQuery.Where(s => s.NameUser.Contains(pUsuario.NameUser));
            if (!string.IsNullOrWhiteSpace(pUsuario.LastNameUser))
                pQuery = pQuery.Where(s => s.LastNameUser.Contains(pUsuario.LastNameUser));
            if (!string.IsNullOrWhiteSpace(pUsuario.Login))
                pQuery = pQuery.Where(s => s.Login.Contains(pUsuario.Login));
            if (pUsuario.Status_User > 0)
                pQuery = pQuery.Where(s => s.Status_User == pUsuario.Status_User);
            if (pUsuario.RegistrationUser.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pUsuario.RegistrationUser.Year, pUsuario.RegistrationUser.Month, pUsuario.RegistrationUser.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.RegistrationUser >= fechaInicial && s.RegistrationUser <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.IdUser).AsQueryable();
            if (pUsuario.Top_Aux > 0)
                pQuery = pQuery.Take(pUsuario.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<UserDev>> BuscarAsync(UserDev pUsuario)
        {
            var Usuarios = new List<UserDev>();
            using (var bdContexto = new SysTaimsalBDContext())
            {
                var select = bdContexto.UserDevs.AsQueryable();
                select = QuerySelect(select, pUsuario);
                Usuarios = await select.ToListAsync();
            }
            return Usuarios;
        }
        #endregion
        public static async Task<List<UserDev>> BuscarIncluirRolesAsync(UserDev pUsuario)
        {
            var usuarios = new List<UserDev>();
            using (var bdContexto = new SysTaimsalBDContext())
            {
                var select = bdContexto.UserDevs.AsQueryable();
                select = QuerySelect(select, pUsuario).Include(s => s.IdRol).AsQueryable();
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        public static async Task<UserDev> LoginAsync(UserDev pUserDev)
        {
            var usuario = new UserDev();
            using (var bdContexto = new SysTaimsalBDContext())
            {
                EncryotMD5(pUserDev); 
                usuario = await bdContexto.UserDevs.FirstOrDefaultAsync(s => s.Login == pUserDev.Login &&
                s.Password == pUserDev.Password && s.Status_User == (byte)Status_Users.ACTIVO);
            }
            return usuario;
        }

        //public static async Task<UserDev> LoginAsync(UserDev pUserDev)
        //{
        //    UserDev userDev;

        //    using (var dbContext = new SysTaimsalBDContext())
        //    {
        //        EncryotMD5(pUserDev);
        //        userDev = await dbContext.UserDevs.
        //            SingleOrDefaultAsync(s => s.Login == pUserDev.Login &&
        //                                 s.Password == pUserDev.Password && 
        //                                 s.Status_User == (byte)Status_Users.ACTIVO);
        //    }

        //    if (userDev == null)
        //    {
        //        // manejar la situación donde no se encuentra un usuario
        //    }

        //    return userDev;
        //}


        //public static async Task<UserDev> LoginAsync(UserDev pUserDev)
        //{
        //    EncryotMD5(pUserDev);

        //    using (var dbContext = new SysTaimsalBDContext())
        //    {

        //        return await dbContext.UserDevs
        //            .SingleOrDefaultAsync(s => s.Login == pUserDev.Login &&
        //                                       s.Password == pUserDev.Password &&
        //                                       s.Status_User == (byte)Status_Users.ACTIVO);
        //    }
        //}


        public static async Task<int> CambiarPasswordAsync(UserDev pUsuario, string pPasswordAnt)
        {
            int result = 0;
            var usuarioPassAnt = new UserDev { Password = pPasswordAnt };
            EncryotMD5(usuarioPassAnt);
            using (var bdContexto = new SysTaimsalBDContext())
            {
                var usuario = await bdContexto.UserDevs.FirstOrDefaultAsync(s => s.IdUser == pUsuario.IdUser);
                if (usuarioPassAnt.Password == usuario.Password)
                {
                    EncryotMD5(pUsuario);
                    usuario.Password = pUsuario.Password;
                    bdContexto.Update(usuario);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("El password actual es incorrecto");
            }
            return result;
        }

    }
}

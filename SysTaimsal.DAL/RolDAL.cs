using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;

namespace SysTaimsal.DAL
{
    public class RolDAL
    {
        public static async Task<int> CrearteAsync(Rol pRol)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                BDContext.Add(pRol);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModifyAsync(Rol pRol)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                var rol = await BDContext.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                rol.NameRol = pRol.NameRol;
                BDContext.Update(rol);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Rol> GetByIdAsync(Rol pRol)
        {
            var rol = new Rol();
            using (var BDContext = new SysTaimsalBDContext())
            {
                rol = await BDContext.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
            }
            return rol;
        }

        public static async Task<List<Rol>> GetAllAsync()
        {
            var roles = new List<Rol>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                roles = await BDContext.Rol.ToListAsync();
            }
            return roles;
        }
        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery, Rol pRol)
        {
            if (pRol.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pRol.IdRol);
            if (!string.IsNullOrWhiteSpace(pRol.NameRol))
                pQuery = pQuery.Where(s => s.NameRol.Contains(pRol.NameRol));
            pQuery = pQuery.OrderByDescending(s => s.IdRol).AsQueryable();
            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Rol>> SearchAsync(Rol pRol)
        {
            var roles = new List<Rol>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                var select = BDContext.Rol.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }
        public static async Task<int> DeleteAsync(Rol pRol)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                var rol = await BDContext.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                BDContext.Rol.Remove(rol);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }
    }
}

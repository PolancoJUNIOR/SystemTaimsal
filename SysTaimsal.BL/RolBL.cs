using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class RolBL
    {
        public async Task<int> CreateAsync(Rol pRol) { 
            return await RolDAL.CrearteAsync(pRol);
        }

        public async Task<int> ModifyAsync(Rol pRol) { 
            return await RolDAL.ModifyAsync(pRol);
        }

        public async Task<Rol> GetByIdAsync(Rol pRol) {
            return await RolDAL.GetByIdAsync(pRol);
        }

        public async Task<List<Rol>> GetAllAsync()
        {   
            return await RolDAL.GetAllAsync();
        }

        public async Task<List<Rol>>SearchAsync (Rol pRol) {
            return await RolDAL.SearchAsync(pRol);
        }

        public async Task<int> DeleteAsync(Rol pRol) { 
            return await RolDAL.DeleteAsync(pRol);
        }
    }
}

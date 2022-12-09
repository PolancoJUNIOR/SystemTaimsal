using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class CLientBL
    {
        public async Task<int> CreateAsync(Client pClient)
        {
            return await CLientDAL.CreateAsync(pClient);
        }

        public async Task<int> ModifyAsync(Client pClient)
        {
            return await CLientDAL.ModifyAsync(pClient);
        }

        public async Task<Client> GetByIdAsync(Client pClient)
        {
            return await CLientDAL.GetByIdAsync(pClient);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await CLientDAL.GetAllAsync();
        }

        public async Task<List<Client>> SearchAsync(Client pClient)
        {
            return await CLientDAL.SearchAsync(pClient);
        }

        public async Task<int> DeleteAsync(Client pClient)
        {
            return await CLientDAL.DeleteAsync(pClient);
        }
    }
}

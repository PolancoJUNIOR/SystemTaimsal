using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class ProviderBL
    {
        public async Task<int> CreateAsync(Provider pProvider)
        {
            return await ProviderDAL.CreateAsync(pProvider);
        }

        public async Task<int> Modify(Provider pProvider)
        {
            return await ProviderDAL.ModifyAsync(pProvider);
        }

        public async Task<Provider> GetByIdAsync(Provider pProvider)
        {
            return await ProviderDAL.GetByIdAsync(pProvider);
        }

        public async Task<List<Provider>> GetAllAsync(Provider pProvider)
        {
            return await ProviderDAL.GetAllAsync();
        }

        public async Task<List<Provider>> SearchAsync(Provider pProvider)
        {
            return await ProviderDAL.SearchAsync(pProvider);
        }

        public async Task<int> DeleteAsync(Provider pProvider)
        {
            return await ProviderDAL.DeleteAsync(pProvider);
        }
    }
}

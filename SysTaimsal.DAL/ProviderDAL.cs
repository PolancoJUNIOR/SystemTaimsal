using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics.Metrics;

namespace SysTaimsal.DAL
{
    public class ProviderDAL
    {
        public static async Task<int> CreateAsync(Provider pProvider) {
            int result = 0;

            using (var DbContext = new SysTaimsalBDContext()) {
                DbContext.Add(pProvider);
                result = await DbContext.SaveChangesAsync();
            }

            return result;
        }

        public static async Task<int> ModifyAsync(Provider pProvider) {
            var result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                var provider = await DbContext.Providers.FirstOrDefaultAsync(s => s.IdProvider == pProvider.IdProvider);
                provider.NameProvider = pProvider.NameProvider;
                DbContext.Update(provider);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Provider> GetByIdAsync(Provider pProvider) {
            var provider = new Provider();
            using (var DbContext = new SysTaimsalBDContext()) {
                provider = await DbContext.Providers.FirstOrDefaultAsync(s => s.IdProvider == pProvider.IdProvider);

            }
            return provider;
        }

        public static async Task<List<Provider>> GetAllAsync()
        {
            var providers = new List<Provider>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                providers = await BDContext.Providers.ToListAsync();
            }
            return providers;
        }

        internal static IQueryable<Provider> QuerySelect(IQueryable<Provider> pQuery, Provider pProvider) {
            if (pProvider.IdProvider > 0)
                pQuery = pQuery.Where(s => s.IdProvider == pProvider.IdProvider);
            if (!string.IsNullOrWhiteSpace(pProvider.NameProvider))
                pQuery = pQuery.Where(s => s.NameProvider.Contains(pProvider.NameProvider));
            pQuery = pQuery.OrderByDescending(s => s.IdProvider).AsQueryable();
            if (pProvider.Top_Aux > 0)
                pQuery = pQuery.Take(pProvider.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Provider>> SearchAsync(Provider pprovider) {
            var providers = new List<Provider>();
            using (var BDContext = new SysTaimsalBDContext()) {
                var select = BDContext.Providers.AsQueryable();
                select = QuerySelect(select, pprovider);
                providers = await select.ToListAsync();
            }
            return providers;
        }

        public static async Task<int> DeleteAsync(Provider pProvider) { 
            int result = 0;
            using (var DbContext = new SysTaimsalBDContext()) { 
                var provider = await DbContext.Providers.FirstOrDefaultAsync(s => s.IdProvider == pProvider.IdProvider);
                DbContext.Providers.Remove(provider);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}

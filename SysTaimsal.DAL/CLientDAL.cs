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
    public class CLientDAL
    {
        public static async Task<int> CreateAsync(Client pClient)
        {
            int result = 0;
            using (var DBContext = new SysTaimsalBDContext())
            {
                DBContext.Add(pClient);
                result = await DBContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModifyAsync(Client pClient)
        {
            int result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                var client = await DbContext.Clients.FirstOrDefaultAsync(s => s.IdClient == pClient.IdClient);
                client.NameClient = pClient.NameClient;
                client.PhoneNumber = pClient.PhoneNumber;
                DbContext.Update(client);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Client> GetByIdAsync(Client pClient)
        {
            var client = new Client();
            using (var dbContext = new SysTaimsalBDContext())
            {
                client = await dbContext.Clients.FirstOrDefaultAsync(s => s.IdClient == pClient.IdClient);

            }
            return client;
        }

        public static async Task<List<Client>> GetAllAsync()
        {
            var client = new List<Client>();
            using (var dbContext = new SysTaimsalBDContext())
            {
                client = await dbContext.Clients.ToListAsync();
            }
            return client;
        }

        internal static IQueryable<Client> QuerySelect(IQueryable<Client> pQuery, Client pClient)
        {

            if (pClient.IdClient > 0)
                pQuery = pQuery.Where(s => s.IdClient == pClient.IdClient);
            if (!string.IsNullOrWhiteSpace(pClient.NameClient)) ;
            pQuery = pQuery.OrderByDescending(s => s.IdClient == pClient.IdClient);
            if (pClient.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pClient.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public static async Task<List<Client>> SearchAsync(Client pClient)
        {
            var clients = new List<Client>();

            using (var dbContext = new SysTaimsalBDContext())
            {
                var select = dbContext.Clients.AsQueryable();
                select = QuerySelect(select, pClient);
                clients = await select.ToListAsync();
            }
            return clients;
        }

        public static async Task<int> DeleteAsync(Client pClient)
        {
            int result = 0;
            using (var dbContext = new SysTaimsalBDContext())
            {
                var client = await dbContext.Clients.FirstOrDefaultAsync(s => s.IdClient == pClient.IdClient);
                dbContext.Clients.Remove(client);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}

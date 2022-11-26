using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SysTaimsal.DAL
{
    public class MachineDAL
    {
        public static async Task<int> CreateAsync(Machine pMachine)
        {
            int result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                DbContext.Add(pMachine);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModifyAsync(Machine pMachine)
        {
            var result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                var machine = await DbContext.Machines.FirstOrDefaultAsync(s => s.IdMachine == pMachine.IdMachine);
                machine.NameMachine = pMachine.NameMachine;
                machine.ImageMachine = pMachine.ImageMachine;
                DbContext.Update(machine);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Machine> GetByIdAsync(Machine pMachine)
        {
            var Machine = new Machine();
            using (var dbContext = new SysTaimsalBDContext())
            {
                Machine = await dbContext.Machines.FirstOrDefaultAsync(s => s.IdMachine == pMachine.IdMachine);

            }
            return Machine;
        }

        public static async Task<List<Machine>> GetAllAsync()
        {
            var Machine = new List<Machine>();
            using (var dbContext = new SysTaimsalBDContext())
            {
                Machine = await dbContext.Machines.ToListAsync();
            }
            return Machine;
        }

        internal static IQueryable<Machine> QuerySelect(IQueryable<Machine> pQuery, Machine pMachine)
        {

            if (pMachine.IdMachine > 0)
                pQuery = pQuery.Where(s => s.IdMachine == pMachine.IdMachine);
            if (!string.IsNullOrWhiteSpace(pMachine.NameMachine))
                pQuery = pQuery.Where(s => s.NameMachine.Contains(pMachine.NameMachine));
            if (!string.IsNullOrWhiteSpace(pMachine.ImageMachine))
                pQuery = pQuery.Where(s => s.ImageMachine.Contains(pMachine.ImageMachine));
          
            if (pMachine.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pMachine.Top_Aux).AsQueryable();
            }
            pQuery = pQuery.OrderByDescending(s => s.IdMachine).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Machine>> SearchAsync(Machine pMachine)
        {
            var Machines = new List<Machine>();

            using (var dbContext = new SysTaimsalBDContext())
            {
                var select = dbContext.Machines.AsQueryable();
                select = QuerySelect(select, pMachine);
                Machines = await select.ToListAsync();
            }
            return Machines;
        }

        public static async Task<int> DeleteAsync(Machine pMachine)
        {
            int result = 0;
            using (var dbContext = new SysTaimsalBDContext())
            {
                var Machine = await dbContext.Machines.FirstOrDefaultAsync(s => s.IdMachine == pMachine.IdMachine);
                dbContext.Machines.Remove(Machine);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}

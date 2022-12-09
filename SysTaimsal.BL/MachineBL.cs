using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class MachineBL
    {
        public async Task<int> CreateAsync(Machine pMachine)
        {
            return await MachineDAL.CreateAsync(pMachine);
        }

        public async Task<int> ModifyAsync(Machine pMachine)
        {
            return await MachineDAL.ModifyAsync(pMachine);
        }

        public async Task<Machine> GetByIdAsync(Machine pMachine)
        {
            return await MachineDAL.GetByIdAsync(pMachine);
        }

        public async Task<List<Machine>> GetAllAsync()
        {
            return await MachineDAL.GetAllAsync();
        }

        public async Task<List<Machine>> SearchAsync(Machine pMachine)
        {
            return await MachineDAL.SearchAsync(pMachine);
        }

        public async Task<int> DeleteAsync(Machine pMachine)
        {
            return await MachineDAL.DeleteAsync(pMachine);
        }
    }
}

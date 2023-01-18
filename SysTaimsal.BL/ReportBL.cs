using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class ReportBL
    {
        public async Task<int> CreateAsync(Report pReport) { 
            return await ReportDAL.CrearteAsync(pReport);
        }

        public async Task<int> ModifyAsync(Report pReport) { 
            return await ReportDAL.ModifyAsync(pReport);
        }
        
        public async Task<Report> GetByIdAsync(Report pReport) { 
            return await ReportDAL.GetByIdAsync(pReport);
        }

        public async Task<List<Report>> GetAllAsync() { 
            return await ReportDAL.GetAllAsync();
        }

        public async Task<List<Report>> SearchAsync(Report pReport) { 
            return await ReportDAL.SearchAsync(pReport);
        }

        public async Task<int> DeleteAsync(Report pReport) { 
            return await ReportDAL.DeleteAsync(pReport);
        }

        public async Task<List<Report>> SearchIncludeClientsAsync(Report pReport) {
            return await ReportDAL.SearchIncludeClientsAsync(pReport);
        }

        public async Task<List<Report>> SearchIncludeProductsAsync(Report pReport) { 
            return await ReportDAL.SearchIncludeProductsAsync(pReport);
        }
    }
}

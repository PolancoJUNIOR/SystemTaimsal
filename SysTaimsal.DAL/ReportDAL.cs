using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;

namespace SysTaimsal.DAL
{
    public class ReportDAL
    {
        public static async Task<int> CrearteAsync(Report pReport)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                BDContext.Add(pReport);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModifyAsync(Report pReport)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                var report = await BDContext.Reports.FirstOrDefaultAsync(s => s.IdReport == pReport.IdReport);
                report.IdReport = pReport.IdReport;
                report.Id = pReport.Id;
                report.IdProduct = pReport.IdProduct;
                report.IdProvider = pReport.IdProvider;
                report.IdClient = pReport.IdClient;
                BDContext.Update(report);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Report> GetByIdAsync(Report pReport)
        {
            var report = new Report();
            using (var BDContext = new SysTaimsalBDContext())
            {
                report = await BDContext.Reports.FirstOrDefaultAsync(s => s.IdReport == pReport.IdReport);
            }
            return report;
        }

        public static async Task<List<Report>> GetAllAsync()
        {
            var reports = new List<Report>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                reports = await BDContext.Reports.ToListAsync();
            }
            return reports;
        }
        internal static IQueryable<Report> QuerySelect(IQueryable<Report> pQuery, Report pReport)
        {
            if (pReport.IdReport > 0)
                pQuery = pQuery.Where(s => s.IdReport == pReport.IdReport);
            if (pReport.IdClient > 0)
                pQuery = pQuery.Where(s => s.IdClient == pReport.IdClient);
            if (pReport.IdProduct > 0)
                pQuery = pQuery.Where(s => s.IdProduct == pReport.IdProduct);
            if (pReport.IdProvider > 0)
                pQuery = pQuery.Where(s => s.IdProvider == pReport.IdProvider);
            if (pReport.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pReport.Id);
            //if (pReport.IdMachine > 0)
            //    pQuery = pQuery.Where(s => s.IdMachine == pReport.IdMachine);
            if (pReport.Top_Aux > 0)
                pQuery = pQuery.Take(pReport.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Report>> SearchAsync(Report pReport)
        {
            var reports = new List<Report>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                var select = BDContext.Reports.AsQueryable();
                select = QuerySelect(select, pReport);
                reports = await select.ToListAsync();
            }
            return reports;
        }

        public static async Task<int> DeleteAsync(Report pReport)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                var report = await BDContext.Reports.FirstOrDefaultAsync(s => s.IdReport == pReport.IdReport);
                BDContext.Reports.Remove(report);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<List<Report>> SearchIncludeProductsAsync(Report pReport)
        {
            var Reports = new List<Report>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                var select = BDContext.Reports.AsQueryable();
                select = QuerySelect(select, pReport).Include(s => s.IdProduct).AsQueryable();
                Reports = await select.ToListAsync();
            }
            return Reports;
        }

        public static async Task<List<Report>> SearchIncludeClientsAsync(Report pReport)
        {
            var Reports = new List<Report>();
            using (var BDContext = new SysTaimsalBDContext())
            {
                var select = BDContext.Reports.AsQueryable();
                select = QuerySelect(select, pReport).Include(s => s.IdClient).AsQueryable();
                Reports = await select.ToListAsync();
            }
            return Reports;
        }

        //public static async Task<List<Report>> SearchIncludeMachinesAsync(Report pReport)
        //{
        //    var Reports = new List<Report>();
        //    using (var BDContext = new SysTaimsalBDContext())
        //    {
        //        var select = BDContext.Reports.AsQueryable();
        //        select = QuerySelect(select, pReport).Include(s => s.IdMachine).AsQueryable();
        //        Reports = await select.ToListAsync();
        //    }
        //    return Reports;
        //}

    }
}

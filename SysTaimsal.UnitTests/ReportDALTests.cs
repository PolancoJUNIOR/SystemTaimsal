using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysTaimsal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;

namespace SysTaimsal.DAL.Tests
{
    [TestClass()]
    public class ReportDALTests
    {
        private static Report reportInitial = new Report { IdReport = 1, IdClient = 2, IdUser = 3, IdMachine=2, IdProduct = 2, IdProvider = 2 };
        [TestMethod()]
        public async Task T1CrearteAsyncTest()
        {
            var report = new Report();
            report.IdUser = reportInitial.IdUser;
            report.IdClient = reportInitial.IdClient;
            report.IdProduct = reportInitial.IdProduct;
            report.IdProvider = reportInitial.IdProvider;
            report.IdMachine = reportInitial.IdMachine;
            int result = await ReportDAL.CrearteAsync(report);
            Assert.AreNotEqual(0, result);
            reportInitial.IdReport = report.IdReport;
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var report = new Report();
            report.IdReport = reportInitial.IdReport;
            report.IdProduct = 2;
            int result = await ReportDAL.ModifyAsync(report);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var report = new Report();
            report.IdReport = reportInitial.IdReport;
            var result = await ReportDAL.GetByIdAsync(report);
            Assert.AreEqual(report.IdReport, result.IdReport);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await ReportDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var report = new Report();
            report.IdProduct = 1;
            report.Top_Aux = 10;
            var result = await ReportDAL.SearchAsync(report);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var report = new Report();
            report.IdReport = reportInitial.IdReport;
            int result = await ReportDAL.DeleteAsync(report);
            Assert.AreNotEqual(0, result);
        }

        //    [TestMethod()]
        //    public void T7SearchIncludeProductsAsyncTest()
        //    {
        //        Assert.Fail();
        //    }

        //    [TestMethod()]
        //    public void T8SearchIncludeClientsAsyncTest()
        //    {
        //        Assert.Fail();
        //    }

        //    [TestMethod()]
        //    public void T9SearchIncludeMachinesAsyncTest()
        //    {
        //        Assert.Fail();
        //    }
    }
}
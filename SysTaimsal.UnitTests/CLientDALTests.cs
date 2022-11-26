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
    public class CLientDALTests
    {
        private static Client clientInitial = new Client { IdClient = 1};
        [TestMethod()]
        public async void T1CreateAsyncTest()
        {
            var client = new Client();
            client.IdClient = clientInitial.IdClient;
            client.NameClient = "Cliente1";
            client.PhoneNumber = 12345;
            int result = await CLientDAL.CreateAsync(client);
            clientInitial.IdClient = client.IdClient;
        }

        [TestMethod()]
        public async void T2ModifyAsyncTest()
        {
            var client = new Client();
            client.IdClient = clientInitial.IdClient;
            client.NameClient = "Cliente1.1";
            client.PhoneNumber = 2345;
            int result = await CLientDAL.ModifyAsync(client);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async void T3GetByIdAsyncTest()
        {
            var client = new Client();
            client.IdClient = clientInitial.IdClient;
            var result = await CLientDAL.GetByIdAsync(client);
            Assert.AreEqual(client.IdClient, result.IdClient);
        }

        [TestMethod()]
        public async void T4GetAllAsyncTest()
        {
            var result = await CLientDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async void T5SearchAsyncTest()
        {
            var client = new Client();
            client.NameClient = "2";
            client.Top_Aux = 10;
            var result = await CLientDAL.SearchAsync(client);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async void T6DeleteAsyncTest()
        {
            var client = new Client();
            client.IdClient = clientInitial.IdClient;
            int result = await CLientDAL.DeleteAsync(client);
            Assert.AreNotEqual(0, result);
        }
    }
}
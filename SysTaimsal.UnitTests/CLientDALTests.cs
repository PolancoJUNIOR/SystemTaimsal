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
        private static Client clientInitial = new Client { IdClient = 78, NameClient = "Juanito Perez", PhoneNumber = "12345678" };

        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var client = new Client();
            client.NameClient = "Cliente1";
            client.PhoneNumber = "1234";
            int result = await CLientDAL.CreateAsync(client);
            Assert.AreNotEqual(0, result);
            clientInitial.IdClient = client.IdClient;
        }       

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var client = new Client();
            client.IdClient = clientInitial.IdClient;
            client.NameClient = clientInitial.NameClient;
            client.PhoneNumber = clientInitial.PhoneNumber;
            int result = await CLientDAL.ModifyAsync(client);
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var client = new Client();
            client.IdClient = clientInitial.IdClient;
            var result = await CLientDAL.GetByIdAsync(client);
            Assert.AreEqual(client.IdClient, result.IdClient);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await CLientDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var client = new Client();
            client.NameClient = "2";
            client.Top_Aux = 10;
            var result = await CLientDAL.SearchAsync(client);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var client = new Client();
            client.IdClient = clientInitial.IdClient;
            int result = await CLientDAL.DeleteAsync(client);
            Assert.AreNotEqual(0, result);
        }
    }
}
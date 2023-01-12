using SysTaimsal.EL;

namespace SysTaimsal.DAL.Tests
{
    [TestClass()]
    public class ProviderDALTests
    {
        private static Provider providerInitial = new Provider { IdProvider = 1 };

        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var provider = new Provider();
            provider.NameProvider = "ProvidersPruebas";
            int result = await ProviderDAL.CreateAsync(provider);
            Assert.AreNotEqual(0, result);
            providerInitial.IdProvider = provider.IdProvider;
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var provider = new Provider();
            provider.IdProvider = providerInitial.IdProvider;
            provider.NameProvider = "";
            int result = await ProviderDAL.ModifyAsync(provider);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var provider = new Provider();
            provider.IdProvider = providerInitial.IdProvider;
            var result = await ProviderDAL.GetByIdAsync(provider);
            Assert.AreEqual(provider.IdProvider, result.IdProvider);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await ProviderDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var provider = new Provider();
            provider.NameProvider = "1";
            provider.Top_Aux = 10;
            var result = await ProviderDAL.SearchAsync(provider);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var provider = new Provider();
            provider.IdProvider = providerInitial.IdProvider;
            int result = await ProviderDAL.DeleteAsync(provider);
            Assert.AreNotEqual(0, result);
        }
    }
}
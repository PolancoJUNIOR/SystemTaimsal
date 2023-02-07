using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysTaimsal.DAL;
using SysTaimsal.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTaimsal.DAL.Tests
{
    [TestClass()]
    public class ProductDALTests
    {
        private static Product ProductInitial = new Product { IdProduct = 1, NameProduct = "Product One", ImageProduct = "...", DescriptionProduct = "Product One Lorem", Price = 10.00M };
        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var product = new Product();
            product.NameProduct = "Product Two";
            product.ImageProduct = "../Img/Products/Producto.jpg";
            product.DescriptionProduct = "Piesa metalica, medidas 12.42H 145.2T";
            product.Price = (decimal?)0.254;
            int result = await ProductDAL.CrearteAsync(product);
            Assert.AreNotEqual(0, result);
            ProductInitial.IdProduct = product.IdProduct;
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var product = new Product();
            product.IdProduct = ProductInitial.IdProduct;
            product.NameProduct = ProductInitial.NameProduct;
            product.ImageProduct = ProductInitial.ImageProduct;
            product.DescriptionProduct = ProductInitial.DescriptionProduct;
            product.Price = (decimal?)ProductInitial.Price;
            int result = await ProductDAL.ModifyAsync(product);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var product = new Product();
            product.IdProduct = ProductInitial.IdProduct;
            var result = await ProductDAL.GetByIdAsync(product);
            Assert.AreEqual(product.IdProduct, result.IdProduct);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await ProductDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var product = new Product();
            product.IdProduct= ProductInitial.IdProduct;
            var result = await ProductDAL.SearchAsync(product);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var product = new Product();
            product.IdProduct = ProductInitial.IdProduct;
            int result = await ProductDAL.DeleteAsync(product);
            Assert.AreNotEqual(0, result);
        }
    }
}
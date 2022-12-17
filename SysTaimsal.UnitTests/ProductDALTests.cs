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
        public async void T1CreateAsyncTest()
        {
            var product = new Product();
            product.IdProduct = ProductInitial.IdProduct;
            product.NameProduct = ProductInitial.NameProduct;
            product.ImageProduct = ProductInitial.ImageProduct;
            product.DescriptionProduct = ProductInitial.DescriptionProduct;
            product.Price = ProductInitial.Price;
            int result = await ProductDAL.CreateAsync(product);
            Assert.AreEqual(0, result);
            ProductInitial.IdProduct = product.IdProduct;
            
        }

        [TestMethod()]
        public async void T2ModifyAsyncTest()
        {
            var product = new Product();
            product.IdProduct = ProductInitial.IdProduct;
            product.NameProduct = "Product Two";
            product.ImageProduct = "../Img/Products/Producto.jpg";
            product.DescriptionProduct = "Piesa metalica, medidas 12.42H 145.2T";
            int result = await ProductDAL.ModifyAsync(product);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async void T3GetByIdAsyncTest()
        {
            var product = new Product();
            product.IdProduct = ProductInitial.IdProduct;
            var result = await ProductDAL.GetByIdAsync(product);
            Assert.AreEqual(product.IdProduct, result.IdProduct);
        }

        [TestMethod()]
        public async void T4GetAllAsyncTest()
        {
            var result = await ProductDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async void T5SearchAsyncTest()
        {
            var product = new Product();
            product.NameProduct = "Product Two";
            product.Top_Aux = 10;
            var result = await ProductDAL.SearchAsync(product);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async void T6DeleteAsyncTest()
        {
            var product = new Product();
            product.IdProduct = ProductInitial.IdProduct;
            int result = await ProductDAL.DeleteAsync(product);
            Assert.AreNotEqual(0, result);
        }
    }
}
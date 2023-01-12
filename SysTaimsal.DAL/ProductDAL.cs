using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;

namespace SysTaimsal.DAL
{
    public class ProductDAL
    {
        public static async Task<int> CrearteAsync(Product pProduct)
        {
            int result = 0;
            using (var BDContext = new SysTaimsalBDContext())
            {
                BDContext.Add(pProduct);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModifyAsync(Product pProduct)
        {
            var result = 0;
            using (var DbContext = new SysTaimsalBDContext())
            {
                var product = await DbContext.Products.FirstOrDefaultAsync(s => s.IdProduct == pProduct.IdProduct);
                product.NameProduct = pProduct.NameProduct;
                product.ImageProduct = pProduct.ImageProduct;
                product.DescriptionProduct = pProduct.DescriptionProduct;
                product.Price = pProduct.Price;
                DbContext.Update(product);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Product> GetByIdAsync(Product pProduct)
        {
            var product = new Product();
            using (var dbContext = new SysTaimsalBDContext())
            {
                product = await dbContext.Products.FirstOrDefaultAsync(s => s.IdProduct == pProduct.IdProduct);

            }
            return product;
        }

        public static async Task<List<Product>> GetAllAsync()
        {
            var product = new List<Product>();
            using (var dbContext = new SysTaimsalBDContext())
            {
                product = await dbContext.Products.ToListAsync();
            }
            return product;
        }

        internal static IQueryable<Product> QuerySelect(IQueryable<Product> pQuery, Product pProduct)
        {

            if (pProduct.IdProduct > 0)
                pQuery = pQuery.Where(s => s.IdProduct == pProduct.IdProduct);
            if (!string.IsNullOrWhiteSpace(pProduct.NameProduct))
            pQuery = pQuery.Where(s => s.NameProduct.Contains(pProduct.NameProduct));
            if (!string.IsNullOrWhiteSpace(pProduct.ImageProduct))
            pQuery = pQuery.Where(s => s.ImageProduct.Contains(pProduct.ImageProduct));
            if (!string.IsNullOrWhiteSpace(pProduct.DescriptionProduct))
            pQuery = pQuery.Where(s => s.DescriptionProduct.Contains(pProduct.DescriptionProduct));
            if (pProduct.Price>0)
                pQuery= pQuery.OrderByDescending(s => s.Price);
            if (pProduct.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pProduct.Top_Aux).AsQueryable();
            }
            pQuery = pQuery.OrderByDescending(s => s.IdProduct).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Product>> SearchAsync(Product pProduct)
        {
            var products = new List<Product>();

            using (var dbContext = new SysTaimsalBDContext())
            {
                var select = dbContext.Products.AsQueryable();
                select = QuerySelect(select, pProduct);
                products = await select.ToListAsync();
            }
            return products;
        }

        public static async Task<int> DeleteAsync(Product pProduct)
        {
            int result = 0;
            using (var dbContext = new SysTaimsalBDContext())
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(s => s.IdProduct == pProduct.IdProduct);
                dbContext.Products.Remove(product);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}

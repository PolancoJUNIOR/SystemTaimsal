using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;
using SysTaimsal.DAL;

namespace SysTaimsal.BL
{
    public class ProductBL
    {
        public async Task<int> CreateAsync(Product pProduct)
        {
            return await ProductDAL.CrearteAsync(pProduct);
        }

        public async Task<int> ModifyAsync(Product pProduct)
        {
            return await ProductDAL.ModifyAsync(pProduct);
        }

        public async Task<Product> GetByIdAsync(Product pProduct)
        {
            return await ProductDAL.GetByIdAsync(pProduct);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await ProductDAL.GetAllAsync();
        }

        public async Task<List<Product>> SearchAsync(Product pProduct)
        {
            return await ProductDAL.SearchAsync(pProduct);
        }

        public async Task<int> DeleteAsync(Product pProduct)
        {
            //En caso de posible fallo, revisar la documentacion Asyncronica Microsoft
            //O Averiguen en que la cague XD
            return await ProductDAL.DeleteAsync(pProduct).ConfigureAwait(false);
        }
    }
}

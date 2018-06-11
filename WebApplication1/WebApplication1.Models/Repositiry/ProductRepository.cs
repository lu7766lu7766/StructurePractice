using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositiry
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public IEnumerable<Products> GetByCateogy(int categoryID)
        {
            return GetAll().Where(x => x.CategoryID == categoryID);
        }

        public Products GetByID(int productID)
        {
            return Get(x => x.ProductID == productID);
        }
    }
}
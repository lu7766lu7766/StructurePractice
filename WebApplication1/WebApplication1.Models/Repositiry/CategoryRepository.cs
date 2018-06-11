using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositiry
{
    public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository
    {
        public Categories GetByID(int categoryID)
        {
            return Get(x => x.CategoryID == categoryID);
        }
    }
}
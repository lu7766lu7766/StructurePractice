using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Interface
{
    public interface ICategoryRepository : IRepository<Categories>
    {
        Categories GetByID(int categoryID);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositiry
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        
    }
}
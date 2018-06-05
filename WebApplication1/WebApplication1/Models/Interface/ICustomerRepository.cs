using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Interface
{
    public interface ICustomerRepository : IDisposable
    {
        void Create(Customers instance);

        void Update(Customers instance);

        void Delete(Customers instance);

        Customers Get(string customerID);

        IQueryable<Customers> GetAll();

        void SaveChanges();
    }
}
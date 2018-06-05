using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Interface
{
    public interface ISuppliersRepository : IDisposable
    {
        void Create(Suppliers instance);

        void Update(Suppliers instance);

        void Delete(Suppliers instance);

        Suppliers Get(string suppliersID);

        IQueryable<Suppliers> GetAll();

        void SaveChanges();
    }
}
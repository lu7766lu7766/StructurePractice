using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebApplication1.Models.Interface
{
    public interface IRepository<T> :IDisposable
        where T : class
    {
        void Create(T instance);

        void Update(T instance);

        void Delete(T instance);

        T Get(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        void SaveChanges();
    }
}
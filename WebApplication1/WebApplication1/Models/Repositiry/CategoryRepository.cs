using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositiry
{
    public class CategoryRepository : ICategoryRepository
    {
        protected NorthwindEntities db
        {
            get;
            private set;
        }

        public CategoryRepository()
        {
            db = new NorthwindEntities();
        }

        public void Create(Categories instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Categories.Add(instance);
                SaveChanges();
            }
        }

        public void Delete(Categories instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                SaveChanges();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public Categories Get(int categoryID)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
        }

        public IQueryable<Categories> GetAll()
        {
            return db.Categories.OrderBy(x => x.CategoryID);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Categories instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                SaveChanges();
            }
        }
    }
}
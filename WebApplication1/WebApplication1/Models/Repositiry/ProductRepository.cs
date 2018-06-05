using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositiry
{
    public class ProductRepository : IProductRepository
    {
        protected NorthwindEntities db
        {
            get;
            private set;
        }

        public ProductRepository()
        {
            db = new NorthwindEntities();
        }
        public void Create(Products instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Products.Add(instance);
                SaveChanges();
            }
        }

        public void Delete(Products instance)
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
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

        public Products Get(int productID)
        {
            return db.Products.FirstOrDefault(x => x.ProductID == productID);
        }

        public IQueryable<Products> GetAll()
        {
            return db.Products.Include(p => p.Categories).OrderByDescending(x => x.ProductID);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Products instance)
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
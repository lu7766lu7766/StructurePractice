using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Interface;
using WebApplication1.Models.Repositiry;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Products> repository;

        public ProductService(IRepository<Products> _repo)
        {
            repository = _repo;
        }

        public IResult Create(Products instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this.repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Products instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this.repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int productID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(productID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(productID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int productID)
        {
            return this.repository.GetAll().Any(x => x.ProductID == productID);
        }

        public Products GetByID(int productID)
        {
            return this.repository.Get(x => x.ProductID == productID);
        }

        public IEnumerable<Products> GetAll()
        {
            return this.repository.GetAll();
        }

        public IEnumerable<Products> GetByCategory(int categoryID)
        {
            return this.repository.GetAll().Where(x => x.CategoryID == categoryID);
        }
    }
}

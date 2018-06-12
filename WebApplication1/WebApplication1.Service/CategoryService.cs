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
    public class CategoryService : ICategoryService
    {
        private IRepository<Categories> repository;

        public CategoryService(IRepository<Categories> _repo)
        {
            repository = _repo;
        }
        public IResult Create(Categories instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Categories instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int categoryID)
        {
            IResult result = new Result(false);

            if (!IsExists(categoryID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = GetByID(categoryID);
                repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int categoryID)
        {
            return repository.GetAll().Any(x => x.CategoryID == categoryID);
        }

        public Categories GetByID(int categoryID)
        {
            return repository.Get(x => x.CategoryID == categoryID);
        }

        public IEnumerable<Categories> GetAll()
        {
            return repository.GetAll();
        }
    }
}

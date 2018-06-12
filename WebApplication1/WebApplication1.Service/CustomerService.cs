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
    public class CustomerService : ICustomerService
    {
        private IRepository<Customers> repository;

        public CustomerService(IRepository<Customers> _repo)
        {
            repository = _repo;
        }
        public IResult Create(Customers instance)
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

        public IResult Update(Customers instance)
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

        public IResult Delete(string customerID)
        {
            IResult result = new Result(false);

            if (!IsExists(customerID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = GetByID(customerID);
                repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(string customerID)
        {
            return repository.GetAll().Any(x => x.CustomerID == customerID);
        }

        public Customers GetByID(string customerID)
        {
            return repository.Get(x => x.CustomerID == customerID);
        }

        public IEnumerable<Customers> GetAll()
        {
            return repository.GetAll();
        }
    }
}

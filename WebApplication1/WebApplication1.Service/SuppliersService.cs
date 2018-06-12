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
    public class SuppliersService : ISuppliersService
    {
        private IRepository<Suppliers> repository = new GenericRepository<Suppliers>();

        public IEnumerable<Suppliers> GetAll()
        {
            return repository.GetAll();
        }
    }
}

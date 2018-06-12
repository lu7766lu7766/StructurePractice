using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Interface
{
    public interface ICustomerService
    {
        IResult Create(Customers instance);

        IResult Update(Customers instance);

        IResult Delete(string customerID);

        bool IsExists(string customerID);

        Customers GetByID(string customerID);

        IEnumerable<Customers> GetAll();
    }
}

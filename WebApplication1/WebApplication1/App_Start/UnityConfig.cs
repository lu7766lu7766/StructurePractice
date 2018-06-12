using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using WebApplication1.Models;
using WebApplication1.Models.Interface;
using WebApplication1.Models.Repositiry;
using WebApplication1.Service;
using WebApplication1.Service.Interface;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            var dbContext = new NorthwindEntities();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //Repository
            container.RegisterType<IRepository<Categories>, GenericRepository<Categories>>(
                new InjectionConstructor(dbContext));
            container.RegisterType<IRepository<Products>, GenericRepository<Products>>(
                new InjectionConstructor(dbContext));
            container.RegisterType<IRepository<Suppliers>, GenericRepository<Suppliers>>(
                new InjectionConstructor(dbContext));
            container.RegisterType<IRepository<Customers>, GenericRepository<Customers>>(
                new InjectionConstructor(dbContext));


            //Service
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ISuppliersService, SuppliersService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
using System.Data.Entity.Infrastructure;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;
using Unity.RegistrationByConvention;
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
            //container.RegisterType<IDbContextFactory, DbContext>(
            //    new HierarchicalLifetimeManager(),
            //    new InjectionConstructor(connectionString));

            //Repository
            container.RegisterType(
                typeof(IRepository<>),
                typeof(GenericRepository<>),
                new TransientLifetimeManager(),
                new InjectionConstructor(dbContext)
                );

            //Service
            container.RegisterTypes(
                AllClasses.FromAssemblies(true, Assembly.Load("WebApplication1.Service")), // 掃描目前已經載入此應用程式的全部組件。
                WithMappings.FromMatchingInterface,
                overwriteExistingMappings: true,
                getName: WithName.Default);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
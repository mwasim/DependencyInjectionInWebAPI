using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.Practices.Unity;
using System.Web.Http;
using DependencyInjectionInWebAPI.Entities;
using Unity.WebApi;

namespace DependencyInjectionInWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICountryRepository, CountryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, CountriesDbEntities>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
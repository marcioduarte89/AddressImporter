using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using AddressImporter.Data;
using AddressImporter.Data.Coordinates;
using AddressImporter.Data.Repositories;
using Autofac;
using Autofac.Integration.WebApi;
using Caching;
using AddressImporter.Services.Filters;

namespace AddressImporter.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ExceptionHandlingAttribute());


            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType(typeof(AddressService.AddressService)).AsImplementedInterfaces();
            builder.RegisterType(typeof(AddressImporterContext)).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType(typeof(CoordinatesRepository)).AsImplementedInterfaces();
            builder.RegisterType(typeof(CacheProvider)).AsImplementedInterfaces().SingleInstance();
            builder.RegisterType(typeof(AddressRepository)).AsImplementedInterfaces().InstancePerLifetimeScope();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}

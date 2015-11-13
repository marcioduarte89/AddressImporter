using AddressImporter.Data;
using AddressImporter.Data.Coordinates;
using AddressImporter.Data.Repositories;
using Autofac;
using Caching;
using AddressImporter.AddressService.Builders;
using AddressImporter.AddressService.ValidationRules;

namespace AddressImporter.DataUploader
{
    public class ContainerManager
    {
        private static IContainer _container;
        public static IContainer GetContainer
        {
            get
            {
                if (_container != null) return _container;

                var builder = new ContainerBuilder();
                builder.RegisterType(typeof(AddressService.AddressService)).AsImplementedInterfaces();
                builder.RegisterType(typeof(AddressBuilder)).AsImplementedInterfaces();
                builder.RegisterType(typeof(AddressValidationRules)).AsImplementedInterfaces();
                builder.RegisterType(typeof(AddressImporterContext)).AsImplementedInterfaces().InstancePerLifetimeScope();
                builder.RegisterType(typeof(CoordinatesRepository)).AsImplementedInterfaces();
                builder.RegisterType(typeof(CacheProvider)).AsImplementedInterfaces().InstancePerLifetimeScope();
                builder.RegisterType(typeof(DataUploader)).AsSelf();
                builder.RegisterType(typeof(AddressRepository)).AsImplementedInterfaces().InstancePerLifetimeScope();
                _container = builder.Build();
                return _container;
            }
        }
    }
}

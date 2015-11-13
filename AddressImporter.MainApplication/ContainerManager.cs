using AddressImporter.Data;
using AddressImporter.Data.Coordinates;
using AddressImporter.Data.Repositories;
using Autofac;
using Caching;

namespace AddressImporter.MainApplication
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
                builder.RegisterType(typeof(AddressImporterContext)).AsImplementedInterfaces().InstancePerLifetimeScope();
                builder.RegisterType(typeof(CoordinatesRepository)).AsImplementedInterfaces();
                builder.RegisterType(typeof(CacheProvider)).AsImplementedInterfaces().InstancePerLifetimeScope();
                builder.RegisterType(typeof(AddressRepository)).AsImplementedInterfaces().InstancePerLifetimeScope();
                builder.RegisterType(typeof(NearestAddressCalculator)).AsSelf();
                _container = builder.Build();
                return _container;
            }
        }
    }
}

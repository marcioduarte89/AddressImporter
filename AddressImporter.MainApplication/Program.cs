using Autofac;

namespace AddressImporter.MainApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = ContainerManager.GetContainer.Resolve<NearestAddressCalculator>();
            application.Run();
        }
    }
}

using Autofac;

namespace AddressImporter.DataUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = ContainerManager.GetContainer.Resolve<DataUploader>();
            application.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressImporter.Common.Interfaces.Services;

namespace AddressImporter.MainApplication
{
    public class NearestAddressCalculator
    {
        private readonly IAddressService _addressService;

        public NearestAddressCalculator(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public void Run()
        {
            string numberOfIndexes;
            int nrOfIndexes;
            Console.WriteLine("Nearest Addresses Calculator:");
            Console.WriteLine("Insert Postal Code");
            string postalCode = Console.ReadLine();
            do
            {
                Console.WriteLine("Insert the number of nearest addresses: ");
                numberOfIndexes = Console.ReadLine();
            } while (!Int32.TryParse(numberOfIndexes, out nrOfIndexes));

            var nearestAddresses = _addressService.Get(postalCode, nrOfIndexes);
            Console.WriteLine("List of Nearest Addresses of " + postalCode + " (in km)");
            foreach (var address in nearestAddresses)
            {
                Console.WriteLine("{0}: {1}", address.PostalCode, address.Distance);
            }
        }
    }
}

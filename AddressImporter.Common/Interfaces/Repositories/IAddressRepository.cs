using System.Collections.Generic;
using AddressImporter.Entities;

namespace AddressImporter.Common.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        /// <summary>
        /// Adds a collection of Addresses to the repository
        /// </summary>
        /// <param name="addressCollection"></param>
        void Add(IEnumerable<Address> addressCollection);

        /// <summary>
        /// Gets a collection with nrOfResults number of results of the nearest addresses to Postal Code
        /// </summary>
        /// <param name="postalCode"></param>
        /// <param name="nrOfResults"></param>
        /// <returns></returns>
        IEnumerable<NearestAddressDetails> Get(string postalCode, int nrOfResults);

    }
}

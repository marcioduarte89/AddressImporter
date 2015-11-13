using System;
using System.Collections.Generic;
using System.Linq;
using AddressImporter.Common.Interfaces;
using AddressImporter.Common.Interfaces.Contexts;
using AddressImporter.Common.Interfaces.Repositories;
using AddressImporter.Entities;

namespace AddressImporter.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IAddressImporterContext _context;
        private readonly ICacheProvider _cacheProvider;

        public AddressRepository(IAddressImporterContext context, ICacheProvider cacheProvider)
        {
            _context = context;
            _cacheProvider = cacheProvider;
        }

        /// <summary>
        /// Adds a collection of Addresses to the repository
        /// </summary>
        /// <param name="addressCollection"></param>
        public void Add(IEnumerable<Address> addressCollection)
        {
            if (addressCollection == null) throw new ArgumentNullException("addressCollection", "Address Collection is null");

            var newAddressList = _context.Addresses.AddRange(addressCollection);
            _context.SaveChanges();

            if (newAddressList.Count() > 1)
            {
                var cartesianProduct = (from j in newAddressList
                                        from y in newAddressList
                                        select new AddressConnections
                          {
                              InitialAddressId = j.Id,
                              FinalAddressId = y.Id,
                              Distance = Common.Helpers.Math.CalculatePythagoreanTheorem(j.Easting, y.Easting, j.Northing, y.Northing)
                          });

                cartesianProduct = cartesianProduct.Where(x => x.InitialAddressId != x.FinalAddressId);
                _context.PerformeBulkInsert(cartesianProduct);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets a collection with nrOfResults number of results of the nearest addresses to Postal Code
        /// </summary>
        /// <param name="postalCode"></param>
        /// <param name="nrOfResults"></param>
        /// <returns></returns>
        public IEnumerable<NearestAddressDetails> Get(string postalCode, int nrOfResults)
        {
            var cachedResults = _cacheProvider.Get<IEnumerable<NearestAddressDetails>>(string.Format("{0}{1}", postalCode, nrOfResults));

            if (cachedResults != null && cachedResults.Any()) return cachedResults;

            var results = (from j in _context.Addresses
                           join y in
                               (from j in _context.AddressConnections
                                join y in _context.Addresses on j.InitialAddressId equals y.Id
                                where y.PostalCode.Replace(" ", "").ToLower() == postalCode
                                orderby j.Distance ascending
                                select new
                                {
                                    Ids = j.FinalAddressId,
                                    Distance = j.Distance
                                }).Take(nrOfResults) on j.Id equals y.Ids
                        orderby y.Distance ascending
                        select new NearestAddressDetails
                        {
                            PostalCode = j.PostalCode,
                            Distance = y.Distance
                        });
            _cacheProvider.Set(string.Format("{0}{1}", postalCode, nrOfResults), results);
            return results;
        }
    }
}

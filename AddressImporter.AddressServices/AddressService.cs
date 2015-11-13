using System.Collections.Generic;
using System.Linq;
using AddressImporter.Common.Interfaces.Repositories;
using AddressImporter.Common.Interfaces.Services;
using AddressImporter.Entities;
using AutoMapper;
using Dtos = AddressImporter.Common.Dtos;

namespace AddressImporter.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            Mapper.CreateMap<NearestAddressDetails, Dtos.NearestAddressDetails>().ReverseMap();
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Adds a collection of Addresses to the repository
        /// </summary>
        /// <param name="addressCollection"></param>
        public void Add(IEnumerable<Address> addressCollection)
        {
            _addressRepository.Add(addressCollection);
        }

        /// <summary>
        /// Gets a collection with nrOfResults number of results of the nearest addresses to Postal Code
        /// </summary>
        /// <param name="postalCode"></param>
        /// <param name="nrOfResults"></param>
        /// <returns></returns>
        public IEnumerable<Dtos.NearestAddressDetails> Get(string postalCode, int nrOfResults)
        {
            return Mapper.Map<List<NearestAddressDetails>, List<Dtos.NearestAddressDetails>>(_addressRepository.Get(postalCode.ToLower().Replace(" ", ""), nrOfResults).ToList());
        }
    }
}

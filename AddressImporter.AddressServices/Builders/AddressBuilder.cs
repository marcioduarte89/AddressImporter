using AddressImporter.Common;
using AddressImporter.Common.Interfaces.Repositories;
using AddressImporter.Common.Interfaces.Services;
using AddressImporter.Entities;

namespace AddressImporter.AddressService.Builders
{
    public class AddressBuilder : IAddressBuilder
    {
        private readonly ICoordinatesRepository _coordinatesRepository;
        private readonly IAddressValidationRules _addressValidationRules;
        public AddressBuilder(ICoordinatesRepository coordinatesRepository, IAddressValidationRules addressValidationRules)
        {
            _coordinatesRepository = coordinatesRepository;
            _addressValidationRules = addressValidationRules;
        }

        /// <summary>
        /// Builds the Address Object
        /// </summary>
        /// <param name="addressLine1"></param>
        /// <param name="addressLine2"></param>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        public Address BuildAddress(string addressLine1, string addressLine2, string city, string postalCode)
        {
            if (!_addressValidationRules.IsAddressValid(postalCode))
                return null;

            Coordinates coordinates = _coordinatesRepository.GetCoordinates(postalCode.Replace(" ", string.Empty));

            if (coordinates == null) return null;

            Address newAddress = new Address()
            {
                AddressLine1 = addressLine1,
                AddressLine2 = addressLine2,
                PostalCode = postalCode,
                City = city,
                Easting = coordinates.Easting,
                Northing = coordinates.Northing
            };
            return newAddress;
        }
    }
}

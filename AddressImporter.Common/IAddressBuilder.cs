using AddressImporter.Entities;

namespace AddressImporter.Common
{
    public interface IAddressBuilder
    {
        /// <summary>
        /// Builds the Address Object
        /// </summary>
        /// <param name="addressLine1"></param>
        /// <param name="addressLine2"></param>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        Address BuildAddress(string addressLine1, string addressLine2, string city, string postalCode);
    }
}

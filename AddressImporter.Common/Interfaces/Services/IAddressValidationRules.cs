namespace AddressImporter.Common.Interfaces.Services
{
    public interface IAddressValidationRules
    {
        /// <summary>
        /// Validates if the Postal Code is valid
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        bool IsAddressValid(string postalCode);
    }
}

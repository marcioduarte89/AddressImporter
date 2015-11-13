using AddressImporter.Entities;

namespace AddressImporter.Common.Interfaces.Repositories
{
    public interface ICoordinatesRepository
    {
        /// <summary>
        /// Gets the Coordinates of a specific Postal Code
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        Coordinates GetCoordinates(string postalCode);
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using AddressImporter.Entities;

namespace AddressImporter.Common.Interfaces.Contexts
{
    public interface IAddressImporterContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<AddressConnections> AddressConnections { get; set; }
        int SaveChanges();
        void PerformeBulkInsert<T>(IEnumerable<T> entities);
    }
}

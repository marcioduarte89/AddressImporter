using System.Collections.Generic;
using System.Data.Entity;
using AddressImporter.Common.Interfaces.Contexts;
using AddressImporter.Data.Mappings;
using AddressImporter.Entities;
using EntityFramework.BulkInsert.Extensions;

namespace AddressImporter.Data
{
    public class AddressImporterContext : DbContext, IAddressImporterContext
    {

        public AddressImporterContext()
            : base("AddressImporter")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AddressConnectionsMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressConnections> AddressConnections { get; set; }
        public void PerformeBulkInsert<T>(IEnumerable<T> entities)
        
        {
            this.BulkInsert(entities);
        }
    }
}

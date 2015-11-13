using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AddressImporter.Entities;

namespace AddressImporter.Data.Mappings
{
    public class AddressConnectionsMap :  EntityTypeConfiguration<AddressConnections>
    {
        public AddressConnectionsMap()
        {
            HasKey(t => new { t.InitialAddressId, t.FinalAddressId });

            // Properties
            this.Property(t => t.InitialAddressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FinalAddressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            ToTable("AddressConnections");

            Property(t => t.InitialAddressId).HasColumnName("InitialAddressId");
            Property(t => t.FinalAddressId).HasColumnName("FinalAddressId");
            Property(t => t.Distance).HasColumnName("Distance");

            // Relationships
            HasRequired(t => t.InitialAddress)
                .WithMany(t => t.InitialConnections)
                .HasForeignKey(d => d.InitialAddressId)
                .WillCascadeOnDelete(false); 

            HasRequired(t => t.FinalAddress)
                .WithMany(t => t.FinalConnections)
                .HasForeignKey(d => d.FinalAddressId)
                .WillCascadeOnDelete(false); 

        }
    }
}

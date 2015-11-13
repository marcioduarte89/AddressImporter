using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressImporter.Entities;

namespace AddressImporter.Data.Mappings
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("Addresses");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            Property(t => t.City).HasColumnName("City");
            Property(t => t.PostalCode).HasColumnName("PostalCode");
            Property(t => t.AddressLine2).HasColumnName("Easting");
            Property(t => t.AddressLine2).HasColumnName("Northing");
        }
    }
}

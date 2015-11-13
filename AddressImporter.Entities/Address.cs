using System.Collections.Generic;
namespace AddressImporter.Entities
{
    public class Address
    {

        public Address()
        {
            InitialConnections = new List<AddressConnections>();
            FinalConnections = new List<AddressConnections>();
        }

        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public double Easting { get; set; }
        public double Northing { get; set; }
        public virtual ICollection<AddressConnections> InitialConnections { get; set; }
        public virtual ICollection<AddressConnections> FinalConnections { get; set; }

    }
}

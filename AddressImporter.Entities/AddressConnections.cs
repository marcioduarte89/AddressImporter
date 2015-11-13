namespace AddressImporter.Entities
{
    public class AddressConnections
    {
        public int InitialAddressId { get; set; }
        public int FinalAddressId { get; set; }
        public double Distance { get; set; }
        public virtual Address InitialAddress { get; set; }
        public virtual Address FinalAddress { get; set; }
    }
}

namespace AddressImporter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        Northing = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Easting = c.Double(nullable: false),
                        Northing1 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AddressConnections",
                c => new
                    {
                        InitialAddressId = c.Int(nullable: false),
                        FinalAddressId = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InitialAddressId, t.FinalAddressId })
                .ForeignKey("dbo.Addresses", t => t.FinalAddressId)
                .ForeignKey("dbo.Addresses", t => t.InitialAddressId)
                .Index(t => t.InitialAddressId)
                .Index(t => t.FinalAddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressConnections", "InitialAddressId", "dbo.Addresses");
            DropForeignKey("dbo.AddressConnections", "FinalAddressId", "dbo.Addresses");
            DropIndex("dbo.AddressConnections", new[] { "FinalAddressId" });
            DropIndex("dbo.AddressConnections", new[] { "InitialAddressId" });
            DropTable("dbo.AddressConnections");
            DropTable("dbo.Addresses");
        }
    }
}

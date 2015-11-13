namespace AddressImporter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistanceAsDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddressConnections", "Distance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddressConnections", "Distance", c => c.Int(nullable: false));
        }
    }
}

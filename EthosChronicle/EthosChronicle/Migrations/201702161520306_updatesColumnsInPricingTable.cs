namespace EthosChronicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesColumnsInPricingTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pricings", "PackageType", c => c.String());
            AddColumn("dbo.Pricings", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Pricings", "PackageOne");
            DropColumn("dbo.Pricings", "PackageTwo");
            DropColumn("dbo.Pricings", "PackageThree");
            DropColumn("dbo.Pricings", "PackageFour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pricings", "PackageFour", c => c.Double(nullable: false));
            AddColumn("dbo.Pricings", "PackageThree", c => c.Double(nullable: false));
            AddColumn("dbo.Pricings", "PackageTwo", c => c.Double(nullable: false));
            AddColumn("dbo.Pricings", "PackageOne", c => c.Double(nullable: false));
            DropColumn("dbo.Pricings", "Price");
            DropColumn("dbo.Pricings", "PackageType");
        }
    }
}

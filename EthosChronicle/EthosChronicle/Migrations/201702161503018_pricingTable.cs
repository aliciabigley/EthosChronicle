namespace EthosChronicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pricings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageOne = c.Double(nullable: false),
                        PackageTwo = c.Double(nullable: false),
                        PackageThree = c.Double(nullable: false),
                        PackageFour = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pricings");
        }
    }
}

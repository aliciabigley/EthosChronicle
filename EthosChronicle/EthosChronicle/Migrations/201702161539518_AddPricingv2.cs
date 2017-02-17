namespace EthosChronicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPricingv2 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Pricings ON INSERT INTO Pricings (Id, PackageType, Price) VALUES (1, 'Package One', 300.00)");
            Sql("SET IDENTITY_INSERT Pricings ON INSERT INTO Pricings (Id, PackageType, Price) VALUES (2, 'Package Two', 700.00)");
            Sql("SET IDENTITY_INSERT Pricings ON INSERT INTO Pricings (Id, PackageType, Price) VALUES (3, 'Package Three', 1500.00)");
            Sql("SET IDENTITY_INSERT Pricings ON INSERT INTO Pricings (Id, PackageType, Price) VALUES (4, 'Package Four', 3000.00)");

        }

        public override void Down()
        {
        }
    }
}

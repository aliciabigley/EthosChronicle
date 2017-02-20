namespace EthosChronicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateToVidInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideographerInfoes", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideographerInfoes", "date");
        }
    }
}

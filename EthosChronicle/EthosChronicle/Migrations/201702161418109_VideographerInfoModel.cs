namespace EthosChronicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideographerInfoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideographerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntervieweeName = c.String(nullable: false),
                        Relationship = c.String(nullable: false),
                        AgeRange = c.String(nullable: false),
                        Location = c.String(),
                        Stories = c.String(),
                        Interviewer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VideographerInfoes");
        }
    }
}

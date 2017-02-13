namespace EthosChronicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4cf487b3-d045-41ac-b44d-33f80b1a4053', N'admin@ethos.com', 0, N'ABoD2MX2gCdH86B91s58MZMOjUXiNZAulhm0Ad0o8CDqjPIyQ0VSJiLIRUPVg8nL/g==', N'b1e8aeac-1911-4f67-956e-f12fd9495f56', NULL, 0, 0, NULL, 1, 0, N'admin@ethos.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'806a061e-9c36-4ebe-ab63-490f1a66a795', N'user@ethos.com', 0, N'ADa4pBRBKpkE7d/Sdtj3tX//J9NX3Y1hahsK2qV1A4xi1n63gKFLoyY5DPKVg42UZw==', N'875e7d57-61fc-420f-abb5-fadf3bf0a652', NULL, 0, 0, NULL, 1, 0, N'user@ethos.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'157acd64-9232-4402-8e77-a6d7dcfbe3a0', N'CanManageUsers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4cf487b3-d045-41ac-b44d-33f80b1a4053', N'157acd64-9232-4402-8e77-a6d7dcfbe3a0')

");
        }
        
        public override void Down()
        {
        }
    }
}

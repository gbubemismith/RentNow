namespace RentNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'568613ea-8738-4f7e-b5c5-e17bb2529b94', N'admin@rentnow.com', 0, N'AHhWFT+bPnLl9Z+spLvHc4aQaNY0un2l+Cb6k3bGTbMb8IIPjZc4/w42kVQ1y5+ggg==', N'e6473c01-daca-4f0a-99b4-f9a46ba327c8', NULL, 0, 0, NULL, 1, 0, N'admin@rentnow.com')
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d62f247-4b72-42bd-8c2f-ce36dc571dc4', N'guest@rentnow.com', 0, N'AKvr+bBpw5nNcgPDj5C5xeD5LwVT0fKJ8OtzUtl2684Yrbd9VB45v/LzO9pbQs44XQ==', N'f54b8c6e-03e1-46a2-bd54-d4fe7641e39e', NULL, 0, 0, NULL, 1, 0, N'guest@rentnow.com')
        
        INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3d9bcc90-e1e5-4245-b1a5-53ab3f5cc6d8', N'CanManageMovies')
        INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'568613ea-8738-4f7e-b5c5-e17bb2529b94', N'3d9bcc90-e1e5-4245-b1a5-53ab3f5cc6d8')

            ");
        }
        
        public override void Down()
        {
        }
    }
}

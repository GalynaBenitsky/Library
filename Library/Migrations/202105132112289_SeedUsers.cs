namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'258b2ee3-fc8f-48e4-b1fd-829a7c7a4705', N'user@test.com', 0, N'AKetnUCoDsh/IeMRg3Hc/Mf5MJK8AgSrcfIquDIm7VQp2L7J1mviLYl0bobzF0KlDA==', N'76ce9d75-f7bf-498c-aaa6-bfcff25868a4', NULL, 0, 0, NULL, 1, 0, N'user@test.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e3a07125-ac5e-4f0f-988f-589e3828541a', N'admin@library.com', 0, N'APeuXHbVafBrjXTZjH5rz79/jJadGKLhiQIXaoMRbOgHZeWpRSt7uHhSfvTsh/fVYQ==', N'e92bde70-2ceb-4b86-ae4b-f71b993ccb85', NULL, 0, 0, NULL, 1, 0, N'admin@library.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e3a07125-ac5e-4f0f-988f-589e3828541a', N'CanManageBooks')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6b810d93-2d4b-42ef-b9ee-98743101c145', N'CanManageMagazines')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3a07125-ac5e-4f0f-988f-589e3828541a', N'6b810d93-2d4b-42ef-b9ee-98743101c145')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3a07125-ac5e-4f0f-988f-589e3828541a', N'e3a07125-ac5e-4f0f-988f-589e3828541a')

            ");
        }

        
        public override void Down()
        {
        }
    }
}

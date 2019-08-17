namespace VidlyOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'248ec50b-0e74-4d0a-aa50-19a68d170e25', N'guest@vidly.com', 0, N'AAOzgXKBmPZlUP9sCHi/lf6VrubftaZznYCu2NfkzfO0Q0gQZL6nwBZf17Mz9ccvSA==', N'9a2900e9-85fb-4b3a-a6c7-f507f1a6adad', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'35df42cc-1665-4f7d-a58e-3bf8b562a588', N'admin@raf.rs', 0, N'ALC2vZLj1yE20YtR1mSGE0RV9iZGoPPOV1n7hxu378DjahLVles3syGeyHjd7oElCA==', N'a9d30fb9-441f-44f5-8257-22cf4f90ca85', NULL, 0, 0, NULL, 1, 0, N'admin@raf.rs')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e11fc4c0-cc01-41d4-a37c-f994dff604da', N'manager@raf.rs', 0, N'AJsgeI/SklpvG4Ffjkz0M5VFcR+UAJD6QsbXL32YMa82vR8uB9t6HdhCAh/og8Ps6g==', N'420a6266-2132-4fbb-a99a-7195c13fdc09', NULL, 0, 0, NULL, 1, 0, N'manager@raf.rs')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'69f49411-6db9-47a1-aa77-0991537bbac2', N'CanManageCar')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'35df42cc-1665-4f7d-a58e-3bf8b562a588', N'69f49411-6db9-47a1-aa77-0991537bbac2')


");
        }
        
        public override void Down()
        {
        }
    }
}

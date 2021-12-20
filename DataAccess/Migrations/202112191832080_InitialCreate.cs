namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Builds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        BuilderID = c.String(nullable: false, maxLength: 128),
                        CaseID = c.Int(nullable: false),
                        CPUID = c.Int(nullable: false),
                        MotherboardID = c.Int(nullable: false),
                        RAMID = c.Int(nullable: false),
                        GPUID = c.Int(nullable: false),
                        PSUID = c.Int(nullable: false),
                        StorageID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.BuilderID)
                .ForeignKey("dbo.Cases", t => t.CaseID, cascadeDelete: true)
                .ForeignKey("dbo.CPUs", t => t.CPUID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.GPUs", t => t.GPUID, cascadeDelete: true)
                .ForeignKey("dbo.Motherboards", t => t.MotherboardID, cascadeDelete: true)
                .ForeignKey("dbo.PSUs", t => t.PSUID, cascadeDelete: true)
                .ForeignKey("dbo.RAMs", t => t.RAMID, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageID, cascadeDelete: true)
                .Index(t => t.BuilderID)
                .Index(t => t.CaseID)
                .Index(t => t.CPUID)
                .Index(t => t.MotherboardID)
                .Index(t => t.RAMID)
                .Index(t => t.GPUID)
                .Index(t => t.PSUID)
                .Index(t => t.StorageID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 256),
                        CommentOwnerID = c.String(nullable: false, maxLength: 128),
                        BuildID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Builds", t => t.BuildID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentOwnerID)
                .Index(t => t.CommentOwnerID)
                .Index(t => t.BuildID);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        NumberOfFans = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CPUs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Socket = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Cores = c.Int(nullable: false),
                        Threads = c.Int(nullable: false),
                        Frequency = c.Double(nullable: false),
                        Watt = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.SuggestedBuilds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CaseID = c.Int(nullable: false),
                        CPUID = c.Int(nullable: false),
                        MotherboardID = c.Int(nullable: false),
                        RAMID = c.Int(nullable: false),
                        GPUID = c.Int(nullable: false),
                        PSUID = c.Int(nullable: false),
                        StorageID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cases", t => t.CaseID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.CPUs", t => t.CPUID, cascadeDelete: true)
                .ForeignKey("dbo.GPUs", t => t.GPUID, cascadeDelete: true)
                .ForeignKey("dbo.Motherboards", t => t.MotherboardID, cascadeDelete: true)
                .ForeignKey("dbo.PSUs", t => t.PSUID, cascadeDelete: true)
                .ForeignKey("dbo.RAMs", t => t.RAMID, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageID, cascadeDelete: true)
                .Index(t => t.CaseID)
                .Index(t => t.CPUID)
                .Index(t => t.MotherboardID)
                .Index(t => t.RAMID)
                .Index(t => t.GPUID)
                .Index(t => t.PSUID)
                .Index(t => t.StorageID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GPUs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Chipset = c.String(),
                        Model = c.String(),
                        Watt = c.Int(nullable: false),
                        Vram = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Socket = c.String(nullable: false),
                        Chipset = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        DdrType = c.Int(nullable: false),
                        Size = c.String(),
                        Watt = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.PSUs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Watt = c.Int(nullable: false),
                        Efficiency = c.String(nullable: false),
                        Modularity = c.Boolean(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.RAMs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Frequency = c.Int(nullable: false),
                        DdrType = c.Int(nullable: false),
                        Storage = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        StorageType = c.String(nullable: false),
                        ReadSpeed = c.Int(nullable: false),
                        WriteSpeed = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Thumbnail = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Storages", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.RAMs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.PSUs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Motherboards", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.GPUs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Games", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.CPUs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.SuggestedBuilds", "StorageID", "dbo.Storages");
            DropForeignKey("dbo.Builds", "StorageID", "dbo.Storages");
            DropForeignKey("dbo.SuggestedBuilds", "RAMID", "dbo.RAMs");
            DropForeignKey("dbo.Builds", "RAMID", "dbo.RAMs");
            DropForeignKey("dbo.SuggestedBuilds", "PSUID", "dbo.PSUs");
            DropForeignKey("dbo.Builds", "PSUID", "dbo.PSUs");
            DropForeignKey("dbo.SuggestedBuilds", "MotherboardID", "dbo.Motherboards");
            DropForeignKey("dbo.Builds", "MotherboardID", "dbo.Motherboards");
            DropForeignKey("dbo.SuggestedBuilds", "GPUID", "dbo.GPUs");
            DropForeignKey("dbo.Builds", "GPUID", "dbo.GPUs");
            DropForeignKey("dbo.SuggestedBuilds", "CPUID", "dbo.CPUs");
            DropForeignKey("dbo.SuggestedBuilds", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Builds", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.SuggestedBuilds", "CaseID", "dbo.Cases");
            DropForeignKey("dbo.Builds", "CPUID", "dbo.CPUs");
            DropForeignKey("dbo.Cases", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "CaseID", "dbo.Cases");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "CommentOwnerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "BuildID", "dbo.Builds");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Builds", "BuilderID", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Games", new[] { "CompanyID" });
            DropIndex("dbo.Storages", new[] { "CompanyID" });
            DropIndex("dbo.RAMs", new[] { "CompanyID" });
            DropIndex("dbo.PSUs", new[] { "CompanyID" });
            DropIndex("dbo.Motherboards", new[] { "CompanyID" });
            DropIndex("dbo.GPUs", new[] { "CompanyID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "CategoryID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "StorageID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "PSUID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "GPUID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "RAMID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "MotherboardID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "CPUID" });
            DropIndex("dbo.SuggestedBuilds", new[] { "CaseID" });
            DropIndex("dbo.CPUs", new[] { "CompanyID" });
            DropIndex("dbo.Cases", new[] { "CompanyID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropIndex("dbo.Comments", new[] { "BuildID" });
            DropIndex("dbo.Comments", new[] { "CommentOwnerID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Builds", new[] { "CategoryID" });
            DropIndex("dbo.Builds", new[] { "StorageID" });
            DropIndex("dbo.Builds", new[] { "PSUID" });
            DropIndex("dbo.Builds", new[] { "GPUID" });
            DropIndex("dbo.Builds", new[] { "RAMID" });
            DropIndex("dbo.Builds", new[] { "MotherboardID" });
            DropIndex("dbo.Builds", new[] { "CPUID" });
            DropIndex("dbo.Builds", new[] { "CaseID" });
            DropIndex("dbo.Builds", new[] { "BuilderID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Games");
            DropTable("dbo.Storages");
            DropTable("dbo.RAMs");
            DropTable("dbo.PSUs");
            DropTable("dbo.Motherboards");
            DropTable("dbo.GPUs");
            DropTable("dbo.Categories");
            DropTable("dbo.SuggestedBuilds");
            DropTable("dbo.CPUs");
            DropTable("dbo.Companies");
            DropTable("dbo.Cases");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Followings");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Builds");
        }
    }
}

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                        Case_ID = c.Int(),
                        Motherboard_ID = c.Int(),
                        CPU_ID = c.Int(),
                        RAM_ID = c.Int(),
                        GPU_ID = c.Int(),
                        PSU_ID = c.Int(),
                        Storage_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.BuilderID)
                .ForeignKey("dbo.Cases", t => t.Case_ID)
                .ForeignKey("dbo.Motherboards", t => t.Motherboard_ID)
                .ForeignKey("dbo.CPUs", t => t.CPU_ID)
                .ForeignKey("dbo.RAMs", t => t.RAM_ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.GPUs", t => t.GPU_ID)
                .ForeignKey("dbo.PSUs", t => t.PSU_ID)
                .ForeignKey("dbo.Storages", t => t.Storage_ID)
                .Index(t => t.BuilderID)
                .Index(t => t.CategoryID)
                .Index(t => t.Case_ID)
                .Index(t => t.Motherboard_ID)
                .Index(t => t.CPU_ID)
                .Index(t => t.RAM_ID)
                .Index(t => t.GPU_ID)
                .Index(t => t.PSU_ID)
                .Index(t => t.Storage_ID);
            
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
                        Text = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                        Model = c.String(),
                        Size = c.String(),
                        NumberOfFans = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Socket = c.String(),
                        Chipset = c.String(),
                        Model = c.String(),
                        DdrType = c.Int(nullable: false),
                        Size = c.String(),
                        Thumbnail = c.String(),
                        Watt = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Case_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.Cases", t => t.Case_ID)
                .Index(t => t.CompanyID)
                .Index(t => t.Case_ID);
            
            CreateTable(
                "dbo.CPUs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Socket = c.String(),
                        Model = c.String(),
                        Cores = c.Int(nullable: false),
                        Threads = c.Int(nullable: false),
                        Frequency = c.Double(nullable: false),
                        Watt = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.RAMs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Model = c.String(),
                        Frequency = c.Int(nullable: false),
                        DdrType = c.Int(nullable: false),
                        Storage = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.PSUs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Watt = c.Int(nullable: false),
                        Efficiency = c.String(),
                        Modularity = c.Boolean(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Model = c.String(),
                        Capacity = c.Int(nullable: false),
                        Type = c.String(),
                        ReadSpeed = c.Int(nullable: false),
                        WriteSpeed = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Name = c.String(),
                        Thumbnail = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
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
            
            CreateTable(
                "dbo.CPUMotherboards",
                c => new
                    {
                        CPU_ID = c.Int(nullable: false),
                        Motherboard_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CPU_ID, t.Motherboard_ID })
                .ForeignKey("dbo.CPUs", t => t.CPU_ID, cascadeDelete: true)
                .ForeignKey("dbo.Motherboards", t => t.Motherboard_ID, cascadeDelete: true)
                .Index(t => t.CPU_ID)
                .Index(t => t.Motherboard_ID);
            
            CreateTable(
                "dbo.RAMMotherboards",
                c => new
                    {
                        RAM_ID = c.Int(nullable: false),
                        Motherboard_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RAM_ID, t.Motherboard_ID })
                .ForeignKey("dbo.RAMs", t => t.RAM_ID, cascadeDelete: true)
                .ForeignKey("dbo.Motherboards", t => t.Motherboard_ID, cascadeDelete: true)
                .Index(t => t.RAM_ID)
                .Index(t => t.Motherboard_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Games", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Storages", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "Storage_ID", "dbo.Storages");
            DropForeignKey("dbo.PSUs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "PSU_ID", "dbo.PSUs");
            DropForeignKey("dbo.GPUs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "GPU_ID", "dbo.GPUs");
            DropForeignKey("dbo.Builds", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Motherboards", "Case_ID", "dbo.Cases");
            DropForeignKey("dbo.RAMMotherboards", "Motherboard_ID", "dbo.Motherboards");
            DropForeignKey("dbo.RAMMotherboards", "RAM_ID", "dbo.RAMs");
            DropForeignKey("dbo.RAMs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "RAM_ID", "dbo.RAMs");
            DropForeignKey("dbo.CPUMotherboards", "Motherboard_ID", "dbo.Motherboards");
            DropForeignKey("dbo.CPUMotherboards", "CPU_ID", "dbo.CPUs");
            DropForeignKey("dbo.CPUs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "CPU_ID", "dbo.CPUs");
            DropForeignKey("dbo.Motherboards", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "Motherboard_ID", "dbo.Motherboards");
            DropForeignKey("dbo.Cases", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Builds", "Case_ID", "dbo.Cases");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Builds", "BuilderID", "dbo.AspNetUsers");
            DropIndex("dbo.RAMMotherboards", new[] { "Motherboard_ID" });
            DropIndex("dbo.RAMMotherboards", new[] { "RAM_ID" });
            DropIndex("dbo.CPUMotherboards", new[] { "Motherboard_ID" });
            DropIndex("dbo.CPUMotherboards", new[] { "CPU_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Games", new[] { "CompanyID" });
            DropIndex("dbo.Storages", new[] { "CompanyID" });
            DropIndex("dbo.PSUs", new[] { "CompanyID" });
            DropIndex("dbo.GPUs", new[] { "CompanyID" });
            DropIndex("dbo.RAMs", new[] { "CompanyID" });
            DropIndex("dbo.CPUs", new[] { "CompanyID" });
            DropIndex("dbo.Motherboards", new[] { "Case_ID" });
            DropIndex("dbo.Motherboards", new[] { "CompanyID" });
            DropIndex("dbo.Cases", new[] { "CompanyID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Builds", new[] { "Storage_ID" });
            DropIndex("dbo.Builds", new[] { "PSU_ID" });
            DropIndex("dbo.Builds", new[] { "GPU_ID" });
            DropIndex("dbo.Builds", new[] { "RAM_ID" });
            DropIndex("dbo.Builds", new[] { "CPU_ID" });
            DropIndex("dbo.Builds", new[] { "Motherboard_ID" });
            DropIndex("dbo.Builds", new[] { "Case_ID" });
            DropIndex("dbo.Builds", new[] { "CategoryID" });
            DropIndex("dbo.Builds", new[] { "BuilderID" });
            DropTable("dbo.RAMMotherboards");
            DropTable("dbo.CPUMotherboards");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Games");
            DropTable("dbo.Storages");
            DropTable("dbo.PSUs");
            DropTable("dbo.GPUs");
            DropTable("dbo.Categories");
            DropTable("dbo.RAMs");
            DropTable("dbo.CPUs");
            DropTable("dbo.Motherboards");
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

namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressesID = c.Int(nullable: false, identity: true),
                        Unitno = c.Int(nullable: false),
                        ComplexName = c.String(nullable: false, maxLength: 255),
                        Streetno = c.String(maxLength: 10),
                        Streetname = c.String(maxLength: 255),
                        AddressTypeID = c.Int(),
                        SuburbID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressesID)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeID)
                .ForeignKey("dbo.Suburbs", t => t.SuburbID)
                .Index(t => t.AddressTypeID)
                .Index(t => t.SuburbID);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        AddressTypeID = c.Int(nullable: false, identity: true),
                        AddressTypeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AddressTypeID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        isApproved = c.Boolean(nullable: false),
                        DepartmentID = c.Int(),
                        GenderID = c.Int(),
                        UserTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID)
                .ForeignKey("dbo.Genders", t => t.GenderID)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeID)
                .Index(t => t.DepartmentID)
                .Index(t => t.GenderID)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        DepartmentDescription = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        GenderName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogsID = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 255),
                        LogDateTime = c.DateTime(nullable: false),
                        UserProfileID = c.Int(),
                        profile_ProfileID = c.Int(),
                    })
                .PrimaryKey(t => t.LogsID)
                .ForeignKey("dbo.Profiles", t => t.profile_ProfileID)
                .Index(t => t.profile_ProfileID);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
            CreateTable(
                "dbo.Suburbs",
                c => new
                    {
                        SuburbID = c.Int(nullable: false, identity: true),
                        SuburbName = c.String(nullable: false, maxLength: 255),
                        PostalCodeID = c.Int(),
                        CityID = c.Int(),
                    })
                .PrimaryKey(t => t.SuburbID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .ForeignKey("dbo.PostalCodes", t => t.PostalCodeID)
                .Index(t => t.PostalCodeID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 255),
                        ProvinceID = c.Int(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Provinces", t => t.ProvinceID)
                .Index(t => t.ProvinceID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
            CreateTable(
                "dbo.PostalCodes",
                c => new
                    {
                        PostalCodeID = c.Int(nullable: false, identity: true),
                        PostalCodeNumber = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.PostalCodeID);
            
            CreateTable(
                "dbo.ProfileAddresses",
                c => new
                    {
                        Profile_ProfileID = c.Int(nullable: false),
                        Addresses_AddressesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ProfileID, t.Addresses_AddressesID })
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Addresses_AddressesID, cascadeDelete: true)
                .Index(t => t.Profile_ProfileID)
                .Index(t => t.Addresses_AddressesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "SuburbID", "dbo.Suburbs");
            DropForeignKey("dbo.Suburbs", "PostalCodeID", "dbo.PostalCodes");
            DropForeignKey("dbo.Suburbs", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceID", "dbo.Provinces");
            DropForeignKey("dbo.Profiles", "UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.Logs", "profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Profiles", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.ProfileAddresses", "Addresses_AddressesID", "dbo.Addresses");
            DropForeignKey("dbo.ProfileAddresses", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Addresses", "AddressTypeID", "dbo.AddressTypes");
            DropIndex("dbo.ProfileAddresses", new[] { "Addresses_AddressesID" });
            DropIndex("dbo.ProfileAddresses", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Cities", new[] { "ProvinceID" });
            DropIndex("dbo.Suburbs", new[] { "CityID" });
            DropIndex("dbo.Suburbs", new[] { "PostalCodeID" });
            DropIndex("dbo.Logs", new[] { "profile_ProfileID" });
            DropIndex("dbo.Profiles", new[] { "UserTypeID" });
            DropIndex("dbo.Profiles", new[] { "GenderID" });
            DropIndex("dbo.Profiles", new[] { "DepartmentID" });
            DropIndex("dbo.Addresses", new[] { "SuburbID" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeID" });
            DropTable("dbo.ProfileAddresses");
            DropTable("dbo.PostalCodes");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.Suburbs");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Logs");
            DropTable("dbo.Genders");
            DropTable("dbo.Departments");
            DropTable("dbo.Profiles");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}

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
                        UnitNo = c.Int(nullable: false),
                        ComplexName = c.String(nullable: false, maxLength: 255),
                        StreetNo = c.String(maxLength: 10),
                        StreetName = c.String(maxLength: 255),
                        AddressType_AddressTypeID = c.Int(),
                        Suburb_SuburbID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressesID)
                .ForeignKey("dbo.AddressTypes", t => t.AddressType_AddressTypeID)
                .ForeignKey("dbo.Suburbs", t => t.Suburb_SuburbID)
                .Index(t => t.AddressType_AddressTypeID)
                .Index(t => t.Suburb_SuburbID);
            
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
                        Department_DepartmentID = c.Int(),
                        Gender_GenderID = c.Int(),
                        UserType_UserTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .ForeignKey("dbo.Genders", t => t.Gender_GenderID)
                .ForeignKey("dbo.UserTypes", t => t.UserType_UserTypeID)
                .Index(t => t.Department_DepartmentID)
                .Index(t => t.Gender_GenderID)
                .Index(t => t.UserType_UserTypeID);
            
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
                        Profile_ProfileID = c.Int(),
                    })
                .PrimaryKey(t => t.LogsID)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID)
                .Index(t => t.Profile_ProfileID);
            
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
                        City_CityID = c.Int(),
                        PostalCode_PostalCodeID = c.Int(),
                    })
                .PrimaryKey(t => t.SuburbID)
                .ForeignKey("dbo.Cities", t => t.City_CityID)
                .ForeignKey("dbo.PostalCodes", t => t.PostalCode_PostalCodeID)
                .Index(t => t.City_CityID)
                .Index(t => t.PostalCode_PostalCodeID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 255),
                        Province_ProvinceID = c.Int(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Provinces", t => t.Province_ProvinceID)
                .Index(t => t.Province_ProvinceID);
            
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
            DropForeignKey("dbo.Addresses", "Suburb_SuburbID", "dbo.Suburbs");
            DropForeignKey("dbo.Suburbs", "PostalCode_PostalCodeID", "dbo.PostalCodes");
            DropForeignKey("dbo.Suburbs", "City_CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Province_ProvinceID", "dbo.Provinces");
            DropForeignKey("dbo.Profiles", "UserType_UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.Logs", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Gender_GenderID", "dbo.Genders");
            DropForeignKey("dbo.Profiles", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.ProfileAddresses", "Addresses_AddressesID", "dbo.Addresses");
            DropForeignKey("dbo.ProfileAddresses", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Addresses", "AddressType_AddressTypeID", "dbo.AddressTypes");
            DropIndex("dbo.ProfileAddresses", new[] { "Addresses_AddressesID" });
            DropIndex("dbo.ProfileAddresses", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Cities", new[] { "Province_ProvinceID" });
            DropIndex("dbo.Suburbs", new[] { "PostalCode_PostalCodeID" });
            DropIndex("dbo.Suburbs", new[] { "City_CityID" });
            DropIndex("dbo.Logs", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Profiles", new[] { "UserType_UserTypeID" });
            DropIndex("dbo.Profiles", new[] { "Gender_GenderID" });
            DropIndex("dbo.Profiles", new[] { "Department_DepartmentID" });
            DropIndex("dbo.Addresses", new[] { "Suburb_SuburbID" });
            DropIndex("dbo.Addresses", new[] { "AddressType_AddressTypeID" });
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

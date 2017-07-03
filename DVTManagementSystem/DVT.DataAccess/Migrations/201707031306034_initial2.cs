namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
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
                        addressType_AddressTypeId = c.Int(),
                        suburb_SuburbID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressesID)
                .ForeignKey("dbo.AddressTypes", t => t.addressType_AddressTypeId)
                .ForeignKey("dbo.Suburbs", t => t.suburb_SuburbID)
                .Index(t => t.addressType_AddressTypeId)
                .Index(t => t.suburb_SuburbID);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        AddressTypeId = c.Int(nullable: false, identity: true),
                        AddressTypeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AddressTypeId);
            
            CreateTable(
                "dbo.Suburbs",
                c => new
                    {
                        SuburbID = c.Int(nullable: false, identity: true),
                        SuburbName = c.String(nullable: false, maxLength: 255),
                        city_CityID = c.Int(),
                        postalCode_PostalCodeID = c.Int(),
                    })
                .PrimaryKey(t => t.SuburbID)
                .ForeignKey("dbo.Cities", t => t.city_CityID)
                .ForeignKey("dbo.PostalCodes", t => t.postalCode_PostalCodeID)
                .Index(t => t.city_CityID)
                .Index(t => t.postalCode_PostalCodeID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 255),
                        province_ProvinceID = c.Int(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Provinces", t => t.province_ProvinceID)
                .Index(t => t.province_ProvinceID);
            
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
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        DepartmentDescription = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
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
                        department_DepartmentID = c.Int(),
                        gender_GenderID = c.Int(),
                        usertype_UserTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileID)
                .ForeignKey("dbo.Departments", t => t.department_DepartmentID)
                .ForeignKey("dbo.Genders", t => t.gender_GenderID)
                .ForeignKey("dbo.UserTypes", t => t.usertype_UserTypeID)
                .Index(t => t.department_DepartmentID)
                .Index(t => t.gender_GenderID)
                .Index(t => t.usertype_UserTypeID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "usertype_UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.Logs", "profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "gender_GenderID", "dbo.Genders");
            DropForeignKey("dbo.Profiles", "department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Addresses", "suburb_SuburbID", "dbo.Suburbs");
            DropForeignKey("dbo.Suburbs", "postalCode_PostalCodeID", "dbo.PostalCodes");
            DropForeignKey("dbo.Suburbs", "city_CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "province_ProvinceID", "dbo.Provinces");
            DropForeignKey("dbo.Addresses", "addressType_AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.Logs", new[] { "profile_ProfileID" });
            DropIndex("dbo.Profiles", new[] { "usertype_UserTypeID" });
            DropIndex("dbo.Profiles", new[] { "gender_GenderID" });
            DropIndex("dbo.Profiles", new[] { "department_DepartmentID" });
            DropIndex("dbo.Cities", new[] { "province_ProvinceID" });
            DropIndex("dbo.Suburbs", new[] { "postalCode_PostalCodeID" });
            DropIndex("dbo.Suburbs", new[] { "city_CityID" });
            DropIndex("dbo.Addresses", new[] { "suburb_SuburbID" });
            DropIndex("dbo.Addresses", new[] { "addressType_AddressTypeId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Logs");
            DropTable("dbo.Genders");
            DropTable("dbo.Profiles");
            DropTable("dbo.Departments");
            DropTable("dbo.PostalCodes");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.Suburbs");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}

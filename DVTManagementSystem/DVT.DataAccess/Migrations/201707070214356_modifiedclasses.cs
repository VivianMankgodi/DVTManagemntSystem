namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedclasses : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Addresses", name: "addressType_AddressTypeID", newName: "AddressTypeID");
            RenameColumn(table: "dbo.Addresses", name: "suburb_SuburbID", newName: "SuburbID");
            RenameColumn(table: "dbo.Profiles", name: "department_DepartmentID", newName: "DepartmentID");
            RenameColumn(table: "dbo.Profiles", name: "gender_GenderID", newName: "GenderID");
            RenameColumn(table: "dbo.Profiles", name: "usertype_UserTypeID", newName: "UserTypeID");
            RenameColumn(table: "dbo.Suburbs", name: "city_CityID", newName: "CityID");
            RenameColumn(table: "dbo.Suburbs", name: "postalCode_PostalCodeID", newName: "PostalCodeID");
            RenameIndex(table: "dbo.Addresses", name: "IX_addressType_AddressTypeID", newName: "IX_AddressTypeID");
            RenameIndex(table: "dbo.Addresses", name: "IX_suburb_SuburbID", newName: "IX_SuburbID");
            RenameIndex(table: "dbo.Profiles", name: "IX_department_DepartmentID", newName: "IX_DepartmentID");
            RenameIndex(table: "dbo.Profiles", name: "IX_gender_GenderID", newName: "IX_GenderID");
            RenameIndex(table: "dbo.Profiles", name: "IX_usertype_UserTypeID", newName: "IX_UserTypeID");
            RenameIndex(table: "dbo.Suburbs", name: "IX_postalCode_PostalCodeID", newName: "IX_PostalCodeID");
            RenameIndex(table: "dbo.Suburbs", name: "IX_city_CityID", newName: "IX_CityID");
            AddColumn("dbo.Logs", "UserProfileID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "UserProfileID");
            RenameIndex(table: "dbo.Suburbs", name: "IX_CityID", newName: "IX_city_CityID");
            RenameIndex(table: "dbo.Suburbs", name: "IX_PostalCodeID", newName: "IX_postalCode_PostalCodeID");
            RenameIndex(table: "dbo.Profiles", name: "IX_UserTypeID", newName: "IX_usertype_UserTypeID");
            RenameIndex(table: "dbo.Profiles", name: "IX_GenderID", newName: "IX_gender_GenderID");
            RenameIndex(table: "dbo.Profiles", name: "IX_DepartmentID", newName: "IX_department_DepartmentID");
            RenameIndex(table: "dbo.Addresses", name: "IX_SuburbID", newName: "IX_suburb_SuburbID");
            RenameIndex(table: "dbo.Addresses", name: "IX_AddressTypeID", newName: "IX_addressType_AddressTypeID");
            RenameColumn(table: "dbo.Suburbs", name: "PostalCodeID", newName: "postalCode_PostalCodeID");
            RenameColumn(table: "dbo.Suburbs", name: "CityID", newName: "city_CityID");
            RenameColumn(table: "dbo.Profiles", name: "UserTypeID", newName: "usertype_UserTypeID");
            RenameColumn(table: "dbo.Profiles", name: "GenderID", newName: "gender_GenderID");
            RenameColumn(table: "dbo.Profiles", name: "DepartmentID", newName: "department_DepartmentID");
            RenameColumn(table: "dbo.Addresses", name: "SuburbID", newName: "suburb_SuburbID");
            RenameColumn(table: "dbo.Addresses", name: "AddressTypeID", newName: "addressType_AddressTypeID");
        }
    }
}

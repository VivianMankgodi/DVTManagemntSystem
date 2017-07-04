namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createinitial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "addressType_AddressTypeId", "dbo.AddressTypes");
            DropForeignKey("dbo.Addresses", "suburb_SuburbID", "dbo.Suburbs");
            DropIndex("dbo.Addresses", new[] { "addressType_AddressTypeId" });
            DropIndex("dbo.Addresses", new[] { "suburb_SuburbID" });
            RenameColumn(table: "dbo.Addresses", name: "addressType_AddressTypeId", newName: "AddressTypeId");
            RenameColumn(table: "dbo.Addresses", name: "suburb_SuburbID", newName: "SuburbID");
            RenameColumn(table: "dbo.Suburbs", name: "city_CityID", newName: "CityID");
            RenameColumn(table: "dbo.Suburbs", name: "postalCode_PostalCodeID", newName: "PostalCodeID");
            RenameIndex(table: "dbo.Suburbs", name: "IX_postalCode_PostalCodeID", newName: "IX_PostalCodeID");
            RenameIndex(table: "dbo.Suburbs", name: "IX_city_CityID", newName: "IX_CityID");
            AlterColumn("dbo.Addresses", "AddressTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "SuburbID", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "AddressTypeId");
            CreateIndex("dbo.Addresses", "SuburbID");
            AddForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes", "AddressTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "SuburbID", "dbo.Suburbs", "SuburbID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "SuburbID", "dbo.Suburbs");
            DropForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.Addresses", new[] { "SuburbID" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
            AlterColumn("dbo.Addresses", "SuburbID", c => c.Int());
            AlterColumn("dbo.Addresses", "AddressTypeId", c => c.Int());
            RenameIndex(table: "dbo.Suburbs", name: "IX_CityID", newName: "IX_city_CityID");
            RenameIndex(table: "dbo.Suburbs", name: "IX_PostalCodeID", newName: "IX_postalCode_PostalCodeID");
            RenameColumn(table: "dbo.Suburbs", name: "PostalCodeID", newName: "postalCode_PostalCodeID");
            RenameColumn(table: "dbo.Suburbs", name: "CityID", newName: "city_CityID");
            RenameColumn(table: "dbo.Addresses", name: "SuburbID", newName: "suburb_SuburbID");
            RenameColumn(table: "dbo.Addresses", name: "AddressTypeId", newName: "addressType_AddressTypeId");
            CreateIndex("dbo.Addresses", "suburb_SuburbID");
            CreateIndex("dbo.Addresses", "addressType_AddressTypeId");
            AddForeignKey("dbo.Addresses", "suburb_SuburbID", "dbo.Suburbs", "SuburbID");
            AddForeignKey("dbo.Addresses", "addressType_AddressTypeId", "dbo.AddressTypes", "AddressTypeId");
        }
    }
}

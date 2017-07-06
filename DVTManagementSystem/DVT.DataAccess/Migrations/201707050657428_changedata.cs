namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "AddressTypeID", "dbo.AddressTypes");
            DropForeignKey("dbo.Addresses", "SuburbID", "dbo.Suburbs");
            DropIndex("dbo.Addresses", new[] { "AddressTypeID" });
            DropIndex("dbo.Addresses", new[] { "SuburbID" });
            RenameColumn(table: "dbo.Addresses", name: "AddressTypeID", newName: "addressType_AddressTypeID");
            RenameColumn(table: "dbo.Addresses", name: "SuburbID", newName: "suburb_SuburbID");
            AlterColumn("dbo.Addresses", "addressType_AddressTypeID", c => c.Int());
            AlterColumn("dbo.Addresses", "suburb_SuburbID", c => c.Int());
            CreateIndex("dbo.Addresses", "addressType_AddressTypeID");
            CreateIndex("dbo.Addresses", "suburb_SuburbID");
            AddForeignKey("dbo.Addresses", "addressType_AddressTypeID", "dbo.AddressTypes", "AddressTypeID");
            AddForeignKey("dbo.Addresses", "suburb_SuburbID", "dbo.Suburbs", "SuburbID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "suburb_SuburbID", "dbo.Suburbs");
            DropForeignKey("dbo.Addresses", "addressType_AddressTypeID", "dbo.AddressTypes");
            DropIndex("dbo.Addresses", new[] { "suburb_SuburbID" });
            DropIndex("dbo.Addresses", new[] { "addressType_AddressTypeID" });
            AlterColumn("dbo.Addresses", "suburb_SuburbID", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "addressType_AddressTypeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Addresses", name: "suburb_SuburbID", newName: "SuburbID");
            RenameColumn(table: "dbo.Addresses", name: "addressType_AddressTypeID", newName: "AddressTypeID");
            CreateIndex("dbo.Addresses", "SuburbID");
            CreateIndex("dbo.Addresses", "AddressTypeID");
            AddForeignKey("dbo.Addresses", "SuburbID", "dbo.Suburbs", "SuburbID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "AddressTypeID", "dbo.AddressTypes", "AddressTypeID", cascadeDelete: true);
        }
    }
}

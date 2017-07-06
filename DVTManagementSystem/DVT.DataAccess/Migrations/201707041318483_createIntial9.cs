namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createIntial9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
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
            
            CreateIndex("dbo.Addresses", "AddressTypeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileAddresses", "Addresses_AddressesID", "dbo.Addresses");
            DropForeignKey("dbo.ProfileAddresses", "Profile_ProfileID", "dbo.Profiles");
            DropIndex("dbo.ProfileAddresses", new[] { "Addresses_AddressesID" });
            DropIndex("dbo.ProfileAddresses", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeID" });
            DropTable("dbo.ProfileAddresses");
            CreateIndex("dbo.Addresses", "AddressTypeId");
        }
    }
}

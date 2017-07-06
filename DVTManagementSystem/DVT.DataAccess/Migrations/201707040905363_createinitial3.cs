namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createinitial3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cities", name: "province_ProvinceID", newName: "ProvinceID");
            RenameIndex(table: "dbo.Cities", name: "IX_province_ProvinceID", newName: "IX_ProvinceID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cities", name: "IX_ProvinceID", newName: "IX_province_ProvinceID");
            RenameColumn(table: "dbo.Cities", name: "ProvinceID", newName: "province_ProvinceID");
        }
    }
}

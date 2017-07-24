namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "ProvinceID", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "ProvinceID" });
            AlterColumn("dbo.Cities", "ProvinceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "ProvinceID");
            AddForeignKey("dbo.Cities", "ProvinceID", "dbo.Provinces", "ProvinceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "ProvinceID", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "ProvinceID" });
            AlterColumn("dbo.Cities", "ProvinceID", c => c.Int());
            CreateIndex("dbo.Cities", "ProvinceID");
            AddForeignKey("dbo.Cities", "ProvinceID", "dbo.Provinces", "ProvinceID");
        }
    }
}

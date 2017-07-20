namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed51 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suburbs", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Suburbs", "PostalCodeID", "dbo.PostalCodes");
            DropIndex("dbo.Suburbs", new[] { "PostalCodeID" });
            DropIndex("dbo.Suburbs", new[] { "CityID" });
            AlterColumn("dbo.Suburbs", "PostalCodeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Suburbs", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Suburbs", "PostalCodeID");
            CreateIndex("dbo.Suburbs", "CityID");
            AddForeignKey("dbo.Suburbs", "CityID", "dbo.Cities", "CityID", cascadeDelete: true);
            AddForeignKey("dbo.Suburbs", "PostalCodeID", "dbo.PostalCodes", "PostalCodeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suburbs", "PostalCodeID", "dbo.PostalCodes");
            DropForeignKey("dbo.Suburbs", "CityID", "dbo.Cities");
            DropIndex("dbo.Suburbs", new[] { "CityID" });
            DropIndex("dbo.Suburbs", new[] { "PostalCodeID" });
            AlterColumn("dbo.Suburbs", "CityID", c => c.Int());
            AlterColumn("dbo.Suburbs", "PostalCodeID", c => c.Int());
            CreateIndex("dbo.Suburbs", "CityID");
            CreateIndex("dbo.Suburbs", "PostalCodeID");
            AddForeignKey("dbo.Suburbs", "PostalCodeID", "dbo.PostalCodes", "PostalCodeID");
            AddForeignKey("dbo.Suburbs", "CityID", "dbo.Cities", "CityID");
        }
    }
}

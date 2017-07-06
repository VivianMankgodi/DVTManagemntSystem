namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createIntial7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfileDepartments", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.ProfileDepartments", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.GenderProfiles", "Gender_GenderID", "dbo.Genders");
            DropForeignKey("dbo.GenderProfiles", "Profile_ProfileID", "dbo.Profiles");
            DropIndex("dbo.ProfileDepartments", new[] { "Profile_ProfileID" });
            DropIndex("dbo.ProfileDepartments", new[] { "Department_DepartmentID" });
            DropIndex("dbo.GenderProfiles", new[] { "Gender_GenderID" });
            DropIndex("dbo.GenderProfiles", new[] { "Profile_ProfileID" });
            CreateIndex("dbo.Profiles", "DepartmentID");
            CreateIndex("dbo.Profiles", "GenderID");
            AddForeignKey("dbo.Profiles", "DepartmentID", "dbo.Departments", "DepartmentID");
            AddForeignKey("dbo.Profiles", "GenderID", "dbo.Genders", "GenderID");
            DropTable("dbo.ProfileDepartments");
            DropTable("dbo.GenderProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenderProfiles",
                c => new
                    {
                        Gender_GenderID = c.Int(nullable: false),
                        Profile_ProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gender_GenderID, t.Profile_ProfileID });
            
            CreateTable(
                "dbo.ProfileDepartments",
                c => new
                    {
                        Profile_ProfileID = c.Int(nullable: false),
                        Department_DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ProfileID, t.Department_DepartmentID });
            
            DropForeignKey("dbo.Profiles", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Profiles", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Profiles", new[] { "GenderID" });
            DropIndex("dbo.Profiles", new[] { "DepartmentID" });
            CreateIndex("dbo.GenderProfiles", "Profile_ProfileID");
            CreateIndex("dbo.GenderProfiles", "Gender_GenderID");
            CreateIndex("dbo.ProfileDepartments", "Department_DepartmentID");
            CreateIndex("dbo.ProfileDepartments", "Profile_ProfileID");
            AddForeignKey("dbo.GenderProfiles", "Profile_ProfileID", "dbo.Profiles", "ProfileID", cascadeDelete: true);
            AddForeignKey("dbo.GenderProfiles", "Gender_GenderID", "dbo.Genders", "GenderID", cascadeDelete: true);
            AddForeignKey("dbo.ProfileDepartments", "Department_DepartmentID", "dbo.Departments", "DepartmentID", cascadeDelete: true);
            AddForeignKey("dbo.ProfileDepartments", "Profile_ProfileID", "dbo.Profiles", "ProfileID", cascadeDelete: true);
        }
    }
}

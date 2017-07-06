namespace DVT.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createIntial6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Profiles", "gender_GenderID", "dbo.Genders");
            DropIndex("dbo.Profiles", new[] { "department_DepartmentID" });
            DropIndex("dbo.Profiles", new[] { "gender_GenderID" });
            RenameColumn(table: "dbo.Profiles", name: "usertype_UserTypeID", newName: "UserTypeID");
            RenameIndex(table: "dbo.Profiles", name: "IX_usertype_UserTypeID", newName: "IX_UserTypeID");
            CreateTable(
                "dbo.ProfileDepartments",
                c => new
                    {
                        Profile_ProfileID = c.Int(nullable: false),
                        Department_DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ProfileID, t.Department_DepartmentID })
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID, cascadeDelete: true)
                .Index(t => t.Profile_ProfileID)
                .Index(t => t.Department_DepartmentID);
            
            CreateTable(
                "dbo.GenderProfiles",
                c => new
                    {
                        Gender_GenderID = c.Int(nullable: false),
                        Profile_ProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gender_GenderID, t.Profile_ProfileID })
                .ForeignKey("dbo.Genders", t => t.Gender_GenderID, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID, cascadeDelete: true)
                .Index(t => t.Gender_GenderID)
                .Index(t => t.Profile_ProfileID);
            
            AddColumn("dbo.Profiles", "DepartmentID", c => c.Int());
            AddColumn("dbo.Profiles", "GenderID", c => c.Int());
            DropColumn("dbo.Profiles", "department_DepartmentID");
            DropColumn("dbo.Profiles", "gender_GenderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "gender_GenderID", c => c.Int());
            AddColumn("dbo.Profiles", "department_DepartmentID", c => c.Int());
            DropForeignKey("dbo.GenderProfiles", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.GenderProfiles", "Gender_GenderID", "dbo.Genders");
            DropForeignKey("dbo.ProfileDepartments", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.ProfileDepartments", "Profile_ProfileID", "dbo.Profiles");
            DropIndex("dbo.GenderProfiles", new[] { "Profile_ProfileID" });
            DropIndex("dbo.GenderProfiles", new[] { "Gender_GenderID" });
            DropIndex("dbo.ProfileDepartments", new[] { "Department_DepartmentID" });
            DropIndex("dbo.ProfileDepartments", new[] { "Profile_ProfileID" });
            DropColumn("dbo.Profiles", "GenderID");
            DropColumn("dbo.Profiles", "DepartmentID");
            DropTable("dbo.GenderProfiles");
            DropTable("dbo.ProfileDepartments");
            RenameIndex(table: "dbo.Profiles", name: "IX_UserTypeID", newName: "IX_usertype_UserTypeID");
            RenameColumn(table: "dbo.Profiles", name: "UserTypeID", newName: "usertype_UserTypeID");
            CreateIndex("dbo.Profiles", "gender_GenderID");
            CreateIndex("dbo.Profiles", "department_DepartmentID");
            AddForeignKey("dbo.Profiles", "gender_GenderID", "dbo.Genders", "GenderID");
            AddForeignKey("dbo.Profiles", "department_DepartmentID", "dbo.Departments", "DepartmentID");
        }
    }
}

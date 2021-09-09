namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        Specialty = c.String(),
                        User_Id = c.Int(nullable: false),
                        userInfo_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.userInfo_id)
                .Index(t => t.userInfo_id);
            
            AddColumn("dbo.UserInfoes", "BirthDate", c => c.String());
            AddColumn("dbo.UserInfoes", "PhoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.UserInfoes", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "Age", c => c.Int(nullable: false));
            DropForeignKey("dbo.Educations", "userInfo_id", "dbo.UserInfoes");
            DropIndex("dbo.Educations", new[] { "userInfo_id" });
            DropColumn("dbo.UserInfoes", "PhoneNumber");
            DropColumn("dbo.UserInfoes", "BirthDate");
            DropTable("dbo.Educations");
        }
    }
}

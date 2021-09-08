namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        applicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.applicationUser_Id)
                .Index(t => t.applicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserInfoes", new[] { "applicationUser_Id" });
            DropTable("dbo.UserInfoes");
        }
    }
}

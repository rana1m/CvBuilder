namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "userInfo_id", "dbo.UserInfoes");
            DropIndex("dbo.Educations", new[] { "userInfo_id" });
            RenameColumn(table: "dbo.Educations", name: "userInfo_id", newName: "UserId");
            AlterColumn("dbo.Educations", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Educations", "UserId");
            AddForeignKey("dbo.Educations", "UserId", "dbo.UserInfoes", "id", cascadeDelete: true);
            DropColumn("dbo.Educations", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Educations", "User_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Educations", "UserId", "dbo.UserInfoes");
            DropIndex("dbo.Educations", new[] { "UserId" });
            AlterColumn("dbo.Educations", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Educations", name: "UserId", newName: "userInfo_id");
            CreateIndex("dbo.Educations", "userInfo_id");
            AddForeignKey("dbo.Educations", "userInfo_id", "dbo.UserInfoes", "id");
        }
    }
}

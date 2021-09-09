namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixPK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "UserId", "dbo.UserInfoes");
            DropIndex("dbo.Educations", new[] { "UserId" });
            RenameColumn(table: "dbo.UserInfoes", name: "UserId", newName: "applicationUser_Id");
            RenameColumn(table: "dbo.Educations", name: "UserId", newName: "userInfo_id");
            RenameIndex(table: "dbo.UserInfoes", name: "IX_UserId", newName: "IX_applicationUser_Id");
            AlterColumn("dbo.Educations", "userInfo_id", c => c.Int());
            CreateIndex("dbo.Educations", "userInfo_id");
            AddForeignKey("dbo.Educations", "userInfo_id", "dbo.UserInfoes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "userInfo_id", "dbo.UserInfoes");
            DropIndex("dbo.Educations", new[] { "userInfo_id" });
            AlterColumn("dbo.Educations", "userInfo_id", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.UserInfoes", name: "IX_applicationUser_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Educations", name: "userInfo_id", newName: "UserId");
            RenameColumn(table: "dbo.UserInfoes", name: "applicationUser_Id", newName: "UserId");
            CreateIndex("dbo.Educations", "UserId");
            AddForeignKey("dbo.Educations", "UserId", "dbo.UserInfoes", "id", cascadeDelete: true);
        }
    }
}

namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUserInfo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserInfoes", name: "applicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.UserInfoes", name: "IX_applicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserInfoes", name: "IX_UserId", newName: "IX_applicationUser_Id");
            RenameColumn(table: "dbo.UserInfoes", name: "UserId", newName: "applicationUser_Id");
        }
    }
}

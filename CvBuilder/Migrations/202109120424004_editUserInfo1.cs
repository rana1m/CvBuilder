namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUserInfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "applicationUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "applicationUserId");
        }
    }
}

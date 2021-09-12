namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUserInfo2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfoes", "applicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "applicationUserId", c => c.Int(nullable: false));
        }
    }
}

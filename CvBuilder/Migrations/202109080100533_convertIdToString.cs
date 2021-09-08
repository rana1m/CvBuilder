namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertIdToString : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserInfoes", "Id");
        }
    }
}

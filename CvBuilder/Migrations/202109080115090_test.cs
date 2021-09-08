namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
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
            AlterColumn("dbo.UserInfoes", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserInfoes", "Id");
        }
    }
}

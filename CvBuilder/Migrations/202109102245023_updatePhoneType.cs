namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePhoneType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}

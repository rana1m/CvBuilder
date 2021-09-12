namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBirthDateTypeOnUserInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "BirthDate", c => c.String());
        }
    }
}

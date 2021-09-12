namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeEducationDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Educations", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Educations", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Educations", "EndDate", c => c.String());
            AlterColumn("dbo.Educations", "StartDate", c => c.String());
            AlterColumn("dbo.UserInfoes", "PhoneNumber", c => c.String());
        }
    }
}

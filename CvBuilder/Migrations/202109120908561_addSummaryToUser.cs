namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSummaryToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Summary");
        }
    }
}

namespace CvBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkExpierenceWithUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Position = c.String(),
                        City = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        userInfo_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.userInfo_id)
                .Index(t => t.userInfo_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "userInfo_id", "dbo.UserInfoes");
            DropIndex("dbo.Experiences", new[] { "userInfo_id" });
            DropTable("dbo.Experiences");
        }
    }
}

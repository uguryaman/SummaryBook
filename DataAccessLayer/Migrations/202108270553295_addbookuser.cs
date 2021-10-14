namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbookuser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookUsers",
                c => new
                    {
                        BookUserId = c.Int(nullable: false, identity: true),
                        BookUserName = c.String(maxLength: 50),
                        BookUserCategory = c.String(maxLength: 50),
                        BookUserWriter = c.String(maxLength: 100),
                        BookUserYear = c.String(maxLength: 50),
                        BookUserSummary = c.String(),
                        BookUserAddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookUserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookUsers");
        }
    }
}

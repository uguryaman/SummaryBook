namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class summaryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "UserId", "dbo.Users");
            DropIndex("dbo.Books", new[] { "UserId" });
            CreateTable(
                "dbo.Summaries",
                c => new
                    {
                        SummaryId = c.Int(nullable: false, identity: true),
                        BookSummary = c.String(),
                        SummaryDate = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SummaryId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Books", "BookStatu", c => c.Boolean(nullable: false));
            DropColumn("dbo.Books", "BookSummary");
            DropColumn("dbo.Books", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "BookSummary", c => c.String());
            DropForeignKey("dbo.Summaries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Summaries", "BookId", "dbo.Books");
            DropIndex("dbo.Summaries", new[] { "UserId" });
            DropIndex("dbo.Summaries", new[] { "BookId" });
            DropColumn("dbo.Books", "BookStatu");
            DropTable("dbo.Summaries");
            CreateIndex("dbo.Books", "UserId");
            AddForeignKey("dbo.Books", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}

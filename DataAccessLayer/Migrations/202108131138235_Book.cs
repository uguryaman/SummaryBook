namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "BookSurname");
            DropColumn("dbo.Books", "BookCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookCategory", c => c.String(maxLength: 100));
            AddColumn("dbo.Books", "BookSurname", c => c.String(maxLength: 50));
        }
    }
}

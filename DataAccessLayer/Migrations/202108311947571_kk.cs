namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookUsers", "BookUserUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookUsers", "BookUserUser");
        }
    }
}

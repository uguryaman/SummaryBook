namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AdminSalt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AdminSalt");
        }
    }
}

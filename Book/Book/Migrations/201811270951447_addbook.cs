namespace Book.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "updated", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "updated");
        }
    }
}

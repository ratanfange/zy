namespace Book.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Book", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Test");
            DropTable("dbo.Author");
        }
    }
}

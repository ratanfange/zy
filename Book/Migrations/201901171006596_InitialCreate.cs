namespace Book.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 100),
                        BookType = c.Byte(nullable: false),
                        BookPrice = c.Int(),
                        IsEable = c.Byte(nullable: false),
                        Created = c.DateTimeOffset(precision: 7),
                        Updated = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}

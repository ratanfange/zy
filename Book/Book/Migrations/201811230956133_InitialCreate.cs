namespace Book.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.Book", newName: "Books");

            CreateTable(
                "dbo.Books",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    BookName = c.String(nullable: false, maxLength: 100),
                    BookType = c.Byte(nullable: false),
                    BookPrice = c.Int(nullable: true), // EF6‚Í[DefaultValue(..)]‚É‚æ‚éŽ©“®¶¬‚É‘Î‰ž‚µ‚Ä‚¢‚È‚¢‚Ì‚ÅŽè“®‚Å’Ç‰Á
                    IsEable = c.Byte(nullable: false),
                    Created = c.DateTime(nullable: true)
                })
                .PrimaryKey(t => new { t.ID })
                .PrimaryKey(t => new { t.BookName })
                .Index(t => t.ID, name: "IndexBooks_Id");
        }

        public override void Down()
        {
            //RenameTable(name: "dbo.Books", newName: "Book");
            DropTable("dbo.Books");
            DropIndex("dbo.Books", "IndexBooks_Id");
        }
    }
}

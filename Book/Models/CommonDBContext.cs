using System.Data.Entity;

namespace Book.Models
{
    public class CommonDBContext : DbContext
    {

        public CommonDBContext() : base("name=BookDbConnectionString")
        {
            System.Data.Entity.Database.SetInitializer<CommonDBContext>(null);
        }

        public DbSet<BookModel> Books { get; set; }

        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }

    }
}
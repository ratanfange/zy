using System.Data.Entity;

namespace Book.Models
{
    public class CommonDBContext : DbContext
    {

        public CommonDBContext() : base("name=BookDbConnectionString")
        {
            System.Data.Entity.Database.SetInitializer<CommonDBContext>(null);
        }

        public DbSet<Books> Books { get; set; }

        public DbSet<Movie> Movies { get; set; }


    }
}
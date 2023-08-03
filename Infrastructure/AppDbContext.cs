using Microsoft.EntityFrameworkCore;
using RESTfulAPI.EntityModels;

namespace RESTfulAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.us($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Product>()
            //    .Property(s => s.)
            //    .HasDefaultValue(true);
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id=1,
                        Name = "Crisps",
                        Price = 30
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Biscuits",
                        Price = 25
                    }
                );
        }
    }
}

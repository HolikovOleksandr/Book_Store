using Book_Store.Configuration;
using Book_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

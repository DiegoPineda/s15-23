using CakeBack.Models.Entidades;
using Microsoft.EntityFrameworkCore;


namespace CackeBack.DAL.Dbcontext
{
    public class CakeDbContext : DbContext
    {
        public CakeDbContext(DbContextOptions<CakeDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

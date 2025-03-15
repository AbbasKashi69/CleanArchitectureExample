

using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Reflection;

namespace Shop.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        //public ApplicationDbContext()
        //{
        //    Database.SetConnectionString("Data Source=.;database=clean_architecture;Integrated Security=true;TrustServerCertificate=true")
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}

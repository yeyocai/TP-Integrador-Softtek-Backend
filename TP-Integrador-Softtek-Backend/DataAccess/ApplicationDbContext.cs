using Microsoft.EntityFrameworkCore;
using TP_Integrador_Softtek_Backend.DataAccess.DatabaseSeeding;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; } 
        public DbSet<Service> Services { get; set; } 
        public DbSet<Work> Works { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
                new ProjectSeeder(),
                new ServiceSeeder(),
                new WorkSeeder()
            };

            foreach(var seeder in seeders)
            {
                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

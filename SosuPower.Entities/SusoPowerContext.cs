using Microsoft.EntityFrameworkCore;

namespace SosuPower.Entities
{
    public class SosuPowerContext: DbContext
    {
        public SosuPowerContext(DbContextOptions<SosuPowerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Tasks)
                .WithMany(t => t.Employees);


            base.OnModelCreating(modelBuilder);
        }


        DbSet<Employee> Employees { get; set; }
        DbSet<Task> Tasks { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

using SosuPower.Entities;

namespace SosuPower.DataAccess
{
    public class SosuPowerContext: DbContext
    {
        public SosuPowerContext(DbContextOptions<SosuPowerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // no config needed at this time.
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Tasks { get; set; }
        public DbSet<Resident> Residents { get; set; }  
    }
}
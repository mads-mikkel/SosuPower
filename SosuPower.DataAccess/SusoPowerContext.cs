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
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entities.Assignment> Tasks { get; set; }
        public DbSet<Resident> Residents { get; set; }  
    }
}
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
            

            base.OnModelCreating(modelBuilder);
        }

        DbSet<Employee> Employees { get; set; }
        DbSet<Entities.Task> Tasks { get; set; }
    }
}
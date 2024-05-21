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

        public SosuPowerContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Employee employee1 = new Employee() { Id = 1, Name = "Poul Andersen" };
            Employee employee2 = new Employee() { Id = 2, Name = "Anders Poulsen" };
            Employee employee3 = new Employee() { Id = 3, Name = "Solvej Måneskin" };

            Entities.Task task1 = new Entities.Task() { Id = 1, Description = "Opvasketøming", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Title = "Opg 1" };
            Entities.Task task2 = new Entities.Task() { Id = 2, Description = "Rengøring", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Title = "Opg 2" };
            Entities.Task task3 = new Entities.Task() { Id = 3, Description = "Madlavning", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Title = "Opg 3" };

            modelBuilder.Entity<Employee>().HasData(employee1, employee2);
            modelBuilder.Entity<Entities.Task>().HasData(task1, task2);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Tasks)
                .WithMany(t => t.Employees)
                .UsingEntity(j =>
                    {
                        j.ToTable("EmployeeTask");
                        j.HasData(
                            new { EmployeesId = 1, TasksId = 2 },
                            new { EmployeesId = 1, TasksId = 3 },
                            new { EmployeesId = 2, TasksId = 2 }
                            );
                    });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace SosuPower.Entities
{
    public class SusoPowerContext : DbContext
    {

    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeTask> Tasks { get; set; }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<EmployeeTask> Employees { get; set; }
    }

    public class EmployeeTask
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}

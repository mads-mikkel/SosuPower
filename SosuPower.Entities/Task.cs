namespace SosuPower.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

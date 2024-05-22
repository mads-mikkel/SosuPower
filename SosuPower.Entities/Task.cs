namespace SosuPower.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Resident Resident { get; set; }
    }
}

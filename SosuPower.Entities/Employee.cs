namespace SosuPower.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Assignment> Tasks { get; set; }
    }
}
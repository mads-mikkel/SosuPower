namespace SosuPower.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
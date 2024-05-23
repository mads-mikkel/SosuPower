namespace SosuPower.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Employee> Employees { get; set; }
    }
}

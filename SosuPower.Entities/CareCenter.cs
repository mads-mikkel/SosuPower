namespace SosuPower.Entities
{
    public class CareCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Resident> Residents { get; set; }

    }
}

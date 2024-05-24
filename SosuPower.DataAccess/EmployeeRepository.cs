using SosuPower.Entities;

namespace SosuPower.DataAccess
{
    public class EmployeeRepository(SosuPowerContext sosuPowerContext):
        Repository<Employee>(sosuPowerContext), IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeesIn(Assignment assignment)
        {
            return sosuPowerContext.Employees.Where(e => e.Assignments.Contains(assignment)).ToList();
        }
    }
}

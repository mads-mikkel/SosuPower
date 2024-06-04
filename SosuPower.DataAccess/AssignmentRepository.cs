using Microsoft.EntityFrameworkCore;

using SosuPower.Entities;

namespace SosuPower.DataAccess
{
    public class AssignmentRepository(SosuPowerContext sosuPowerContext):
        Repository<Assignment>(sosuPowerContext), IAssignmentRepository
    {
        public IEnumerable<Assignment> GetAssignmentsFor(Employee employee)
        {
            return sosuPowerContext.Tasks.Where(a => a.Employees.Contains(employee));
        }

        public IEnumerable<Assignment> GetAssignmentsForEmplyeeByDate(int employeeId, DateTime date)
        {
            Employee employee = sosuPowerContext.Employees.Find(employeeId);
            return sosuPowerContext.Tasks.Where(a => a.Employees.Contains(employee) && a.StartTime.Date == date.Date).ToList();
        }

        public IEnumerable<Assignment> GetAssignmentsOn(DateTime date)
        {
            return sosuPowerContext.Tasks.Where(a => a.StartTime == date.Date);
        }

        public override Assignment GetBy(int id)
        {
            return sosuPowerContext.Tasks.Include(a => a.Employees).FirstOrDefault(a => a.Id == id);
        }
    }
}

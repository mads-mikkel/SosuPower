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

        public IEnumerable<Assignment> GetAssignmentsFor(string employeeName)
        {
            throw new UseYourHeadException("IT'S ALL OBJECTS!!!");

            /*return sosuPowerContext.Employees
                .Where(e => e.Name == employeeName)
                .SelectMany(e => e.Tasks)
                .ToList();*/
        }

        public IEnumerable<Assignment> GetAssignmentsOn(DateTime date)
        {
            return sosuPowerContext.Tasks.Where(a => a.StartTime == date.Date);
        }
    }
}

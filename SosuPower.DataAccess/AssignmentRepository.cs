using SosuPower.Entities;

namespace SosuPower.DataAccess
{
    public class AssignmentRepository(SosuPowerContext sosuPowerContext): 
        Repository<Assignment>(sosuPowerContext), IAssignmentRepository
    {        

        public IEnumerable<Assignment> GetAssignmentsOn(DateTime date)
        {
            return sosuPowerContext.Tasks.Where(a => a.StartTime == date.Date);
        }
    }
}

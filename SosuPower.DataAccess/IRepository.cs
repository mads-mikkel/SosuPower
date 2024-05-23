using SosuPower.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosuPower.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetBy(int id);
    }

    public interface IAssignmentRepository : IRepository<Assignment>
    {
        IEnumerable<Assignment> GetAssignmentsOn(DateTime date);
        IEnumerable<Assignment> GetAssignmentsFor(Employee employee);
        IEnumerable<Assignment> GetAssignmentsFor(string employeeName);
    }

    public interface IEmployeeRepository : IRepository<Employee>
    {

    }
}

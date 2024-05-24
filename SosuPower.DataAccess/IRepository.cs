using SosuPower.Entities;

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

    public interface IAssignmentRepository: IRepository<Assignment>
    {
        IEnumerable<Assignment> GetAssignmentsOn(DateTime date);
        IEnumerable<Assignment> GetAssignmentsFor(Employee employee);
    }

    public interface IEmployeeRepository: IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesIn(Assignment assignment);
    }

    //public interface IResidentRepository: IRepository<Resident> { }
}
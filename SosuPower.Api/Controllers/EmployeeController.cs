using Microsoft.AspNetCore.Mvc;

using SosuPower.DataAccess;
using SosuPower.Entities;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(IEmployeeRepository repository): Controller
    {
        private readonly IEmployeeRepository repository = repository;

        [HttpGet(nameof(GetById))]
        public ActionResult<Employee> GetById(int id)
        {
            return repository.GetBy(id);
        }

        [HttpGet(nameof(GetAll))]
        public IEnumerable<Employee> GetAll()
        {
            return repository.GetAll();
        }

        [HttpPost]
        public void AddNew([FromQuery] Employee employee)
        {
            repository.Add(employee);
        }

        [HttpPut]
        public void Update([FromQuery] Employee employee)
        {
            repository.Update(employee);
        }

        [HttpDelete(nameof(DeleteById))]
        public void DeleteById(int id)
        {
            repository.Delete(id);
        }
    }
}
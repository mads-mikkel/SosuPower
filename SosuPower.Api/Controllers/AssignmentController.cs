using Microsoft.AspNetCore.Mvc;

using SosuPower.DataAccess;
using SosuPower.Entities;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController(IAssignmentRepository repository): Controller
    {
        private readonly IAssignmentRepository repository = repository;

        [HttpGet]
        public IEnumerable<Assignment> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet(nameof(GetBy))]
        public ActionResult<Assignment> GetBy(int id)
        {
            return repository.GetBy(id);
        }

        [HttpGet(nameof(GetAssignmentsByDate))]
        public IEnumerable<Assignment> GetAssignmentsByDate(DateTime date = default)
        {
            if(date == default)
                date = DateTime.Now;
            return repository.GetAssignmentsOn(date);
        }

        [HttpGet(nameof(GetAssignmentsForEmployee))]
        public IEnumerable<Assignment> GetAssignmentsForEmployee([FromQuery] Employee employee)
        {
            return repository.GetAssignmentsFor(employee);
        }

        [HttpPost]
        public void AddNew([FromQuery] Assignment task)
        {
            repository.Add(task);
        }

        [HttpPut]
        public void Update([FromBody] Assignment assignment)
        {
            repository.Update(assignment);
        }

        [HttpDelete(nameof(DeleteById))]
        public void DeleteById(int id) 
        {
            repository.Delete(id);
        }

        [HttpDelete]
        public void Delete(Assignment assignment)
        {
            repository.Delete(assignment); ;
        }
    }
}

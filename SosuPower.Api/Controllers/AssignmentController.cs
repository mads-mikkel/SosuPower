using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SosuPower.DataAccess;
using SosuPower.Entities;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet(nameof(GetTasksFor))]
        public IEnumerable<Assignment> GetTasksFor(DateTime date = default)
        {
            return repository.GetAssignmentsOn(date);
        }

        [HttpPost]
        public void AddNew(Assignment task)
        {
            repository.Add(task);
        }

        [HttpPut]
        public void Update(Assignment assignment)
        {
            repository.Update(assignment);
        }

        [HttpDelete("DeleteById")]
        public void Delete(int id) 
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

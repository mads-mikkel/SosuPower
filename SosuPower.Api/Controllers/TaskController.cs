using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SosuPower.DataAccess;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: Controller
    {
        private readonly IRepository<Entities.Assignment> repository;

        public TaskController(IRepository<Entities.Assignment> repository)
        {
            this.repository = repository;
        }

        [HttpGet(nameof(GetBy))]
        public ActionResult<Entities.Assignment> GetBy(int id)
        {
            return repository.GetBy(id);
        }

        [HttpGet(nameof(GetTasksFor))]
        public IEnumerable<Entities.Assignment> GetTasksFor(DateTime date = default)
        {
            return default;
        }

        [HttpPost]
        public void AddNew(Entities.Assignment task)
        {
            repository.Add(task);
        }
    }
}

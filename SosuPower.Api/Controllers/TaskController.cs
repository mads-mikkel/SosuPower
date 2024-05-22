using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SosuPower.DataAccess;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: Controller
    {
        private readonly IRepository<Entities.Task> repository;

        public TaskController(IRepository<Entities.Task> repository)
        {
            this.repository = repository;
        }

        [HttpGet(nameof(GetBy))]
        public ActionResult<Entities.Task> GetBy(int id)
        {
            return repository.GetBy(id);
        }

        [HttpGet(nameof(GetTasksFor))]
        public IEnumerable<Entities.Task> GetTasksFor(DateTime date = default)
        {
            return default;
        }

        [HttpPost]
        public void AddNew(Entities.Task task)
        {
            repository.Add(task);
        }
    }
}

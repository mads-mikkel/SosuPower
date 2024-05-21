using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SosuPower.DataAccess;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: Controller
    {
        private readonly SosuPowerContext context;

        public TaskController(SosuPowerContext context)
        {
            this.context = context;
        }

        [HttpGet(nameof(GetBy))]
        public ActionResult<Entities.Task> GetBy(int id)
        {
            Entities.Task task = context.Tasks
                .Include(t => t.Resident)
                .FirstOrDefault(t => t.Id == id);
            return task;
        }

        [HttpGet(nameof(GetTasksFor))]
        public IEnumerable<Entities.Task> GetTasksFor(DateTime date = default)
        {
            List<Entities.Task> tasks = context.Tasks
                .Where(t => t.StartTime.Date == date.Date)
                .ToList();
            return tasks;
        }

        [HttpPost]
        public void AddNew(Entities.Task task)
        {
            context.Entry(task.Resident).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.Tasks.Add(task);
            context.SaveChanges();
        }
    }
}

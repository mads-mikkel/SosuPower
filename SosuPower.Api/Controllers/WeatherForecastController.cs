using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SosuPower.DataAccess;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController: ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Entities.Task> Get()
        {
            SosuPowerContext sosuPowerContext = new();
            List<Entities.Task> tasks = 
                sosuPowerContext.Tasks
                .Include(t => t.Employees)
                .Where(t => t.StartTime >= DateTime.Now && t.EndTime <= DateTime.Now.AddHours(2))
                .ToList();
            return tasks;
        }
    }
}

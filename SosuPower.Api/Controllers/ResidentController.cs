using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SosuPower.DataAccess;
using SosuPower.Entities;

namespace SosuPower.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidentController(IRepository<Resident> repository): ControllerBase
    {
        private readonly IRepository<Resident> repository = repository;

        [HttpGet(nameof(GetById))]
        public ActionResult<Resident> GetById(int id)
        {
            return repository.GetBy(id);
        }

        [HttpGet(nameof(GetAll))]
        public IEnumerable<Resident> GetAll()
        {
            return repository.GetAll();
        }

        [HttpPost]
        public void AddNew([FromQuery] Resident resident)
        {
            repository.Add(resident);
        }

        [HttpPut]
        public void Update([FromQuery] Resident resident)
        {
            repository.Update(resident);
        }

        [HttpDelete(nameof(DeleteById))]
        public void DeleteById(int id)
        {
            repository.Delete(id);
        }
    }
}

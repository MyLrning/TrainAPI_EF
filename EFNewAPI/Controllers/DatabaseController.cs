using EFNewAPI.Settings;
using Microsoft.AspNetCore.Mvc;

namespace EFNewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : Controller
    {
        private readonly TasksContext _dbContext;

        public DatabaseController(TasksContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Get()
        {
            return Ok(_dbContext.Database.EnsureCreated());
        }
    }
}

using EFNewAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFNewAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskService.Get();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Duty task)
        {
            _taskService.Add(task);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Models.Duty task)
        {
            _taskService.Update(id, task);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return Ok();
        }
    }
}

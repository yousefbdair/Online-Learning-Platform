using Microsoft.AspNetCore.Mvc;

using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseObjectiveController : ControllerBase
    {
        private readonly ICourseObjectiveService courseObjectiveService;
        public CourseObjectiveController(ICourseObjectiveService _courseObjectiveService)
        {
            courseObjectiveService = _courseObjectiveService;
        }

        [HttpGet("course/{courseId}")]
        public ActionResult<List<Courseobjective>> GetByCourseId(int courseId)
        {
            return Ok(courseObjectiveService.GetObjectivesByCourseId(courseId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Courseobjective objective)
        {
            courseObjectiveService.CreateCourseObjective(objective);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Courseobjective objective)
        {
            courseObjectiveService.UpdateCourseObjective(objective);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            courseObjectiveService.DeleteCourseObjective(id);
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursePrerequisitesController : ControllerBase
    {
        private readonly ICoursePrerequisitesService coursePrerequisitesService;
        public CoursePrerequisitesController(ICoursePrerequisitesService _coursePrerequisitesService)
        {
            coursePrerequisitesService = _coursePrerequisitesService;
        }

        [HttpGet]
        public ActionResult<List<Courseprerequisite>> GetAll()
        {
            return Ok(coursePrerequisitesService.GetAllCoursePrerequisites());
        }

        [HttpGet("course/{courseId}")]
        public ActionResult<List<Courseprerequisite>> GetByCourseId(int courseId)
        {
            return Ok(coursePrerequisitesService.GetPrerequisitesByCourseId(courseId));
        }

        [HttpGet("{id}")]
        public ActionResult<Courseprerequisite> GetById(int id)
        {
            var item = coursePrerequisitesService.GetCoursePrerequisiteById(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Courseprerequisite prerequisite)
        {
            coursePrerequisitesService.CreateCoursePrerequisite(prerequisite);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Courseprerequisite prerequisite)
        {
            coursePrerequisitesService.UpdateCoursePrerequisite(prerequisite);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            coursePrerequisitesService.DeleteCoursePrerequisite(id);
            return Ok();
        }
    }
}
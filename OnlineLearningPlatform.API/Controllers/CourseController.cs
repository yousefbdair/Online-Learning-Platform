using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService _courseService)
        {
            courseService = _courseService;
        }

        [HttpGet]
        public ActionResult<List<Course>> GetAll()
        {
            return Ok(courseService.GetAllCourses());
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = courseService.GetCourseById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            courseService.CreateCourse(course);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Course course)
        {
            courseService.UpdateCourse(course);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            courseService.DeleteCourse(id);
            return Ok();
        }
    }
}
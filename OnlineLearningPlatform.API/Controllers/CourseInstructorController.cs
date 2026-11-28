using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseInstructorController : ControllerBase
    {
        private readonly ICourseInstructorService courseInstructorService;
        public CourseInstructorController(ICourseInstructorService _courseInstructorService)
        {
            courseInstructorService = _courseInstructorService;
        }

        [HttpGet]
        public ActionResult<List<CourseInstructor>> GetAll()
        {
            return Ok(courseInstructorService.GetAllCourseInstructors());
        }

        [HttpGet("course/{courseId}")]
        public ActionResult<List<CourseInstructor>> GetByCourseId(int courseId)
        {
            return Ok(courseInstructorService.GetByCourseId(courseId));
        }

        [HttpGet("instructor/{instructorId}")]
        public ActionResult<List<CourseInstructor>> GetByInstructorId(int instructorId)
        {
            return Ok(courseInstructorService.GetByInstructorId(instructorId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CourseInstructor courseInstructor)
        {
            courseInstructorService.CreateCourseInstructor(courseInstructor);
            return Ok();
        }

        [HttpDelete("{courseId}/{instructorId}")]
        public IActionResult Delete(int courseId, int instructorId)
        {
            courseInstructorService.DeleteCourseInstructor(courseId, instructorId);
            return Ok();
        }
    }
}
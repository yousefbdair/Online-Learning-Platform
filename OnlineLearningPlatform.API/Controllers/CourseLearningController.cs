using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Service;
using System.Security.Claims;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/learning")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class CourseLearningController : ControllerBase
    {
        private readonly ICourseLearningService learningService;

        public CourseLearningController(ICourseLearningService _learningService)
        {
            learningService = _learningService;
        }

        private decimal StudentId =>
            decimal.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        // GET api/learning/course/5
        [HttpGet("course/{courseId}")]
        public IActionResult GetCourse(decimal courseId)
        {
            var result = learningService.GetCourseLearning(StudentId, courseId);
            if (result == null)
                return StatusCode(403, "You are not enrolled in this course");
            return Ok(result);
        }

        // POST api/learning/course/5/lesson/12/complete
        [HttpPost("course/{courseId}/lesson/{lessonId}/complete")]
        public IActionResult CompleteLesson(decimal courseId, decimal lessonId)
        {
            var ok = learningService.CompleteLesson(StudentId, courseId, lessonId);
            if (!ok)
                return StatusCode(403, "Not enrolled or lesson does not belong to this course");

            // نرجّع التقدم الجديد
            return Ok(learningService.GetCourseLearning(StudentId, courseId));
        }
    }
}
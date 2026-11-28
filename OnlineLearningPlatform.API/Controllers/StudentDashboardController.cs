
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Service;
using System.Security.Claims;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class StudentDashboardController : ControllerBase
    {
        private readonly IStudentDashboardService dashboardService;

        public StudentDashboardController(IStudentDashboardService _dashboardService)
        {
            dashboardService = _dashboardService;
        }

        // GET api/student/my-courses
        [HttpGet("my-courses")]
        public List<MyCourseDto> GetMyCourses()
        {
            // الـ Id من الـ Token مش من الـ URL
            var studentId = decimal.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return dashboardService.GetMyCourses(studentId);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/admin/dashboard")]
    [ApiController]
    [Authorize(Roles = "Admin")]   // فعّليه بعد ما نعمل JWT
    public class AdminDashboardController : ControllerBase
    {
        private readonly IDashboardService dashboardService;

        public AdminDashboardController(IDashboardService _dashboardService)
        {
            dashboardService = _dashboardService;
        }

        [HttpGet("stats")]
        public AdminStatsDto GetStats()
        {
            return dashboardService.GetAdminStats();
        }

        [HttpGet("recent-enrollments")]
        public List<RecentEnrollmentDto> GetRecentEnrollments()
        {
            return dashboardService.GetRecentEnrollments();
        }

        [HttpGet("popular-courses")]
        public List<PopularCourseDto> GetPopularCourses()
        {
            return dashboardService.GetPopularCourses();
        }
    }
}
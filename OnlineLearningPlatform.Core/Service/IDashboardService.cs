using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.DTOs;

namespace OnlineLearningPlatform.Core.Service
{
    public interface IDashboardService
    {
        AdminStatsDto GetAdminStats();
        List<RecentEnrollmentDto> GetRecentEnrollments();
        List<PopularCourseDto> GetPopularCourses();
    }
}
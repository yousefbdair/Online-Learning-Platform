using OnlineLearningPlatform.Core.DTOs;

namespace OnlineLearningPlatform.Core.Service
{
    public interface IStudentDashboardService
    {
        List<MyCourseDto> GetMyCourses(decimal studentId);
    }
}
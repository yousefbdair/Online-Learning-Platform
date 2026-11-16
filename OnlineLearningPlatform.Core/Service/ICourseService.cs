using OnlineLearningPlatform.API.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ICourseService
    {
        public List<Course> GetAllCourses();
        public Course? GetCourseById(int id);
        public void CreateCourse(Course course);
        public void UpdateCourse(Course course);
        public void DeleteCourse(int id);
    }
}
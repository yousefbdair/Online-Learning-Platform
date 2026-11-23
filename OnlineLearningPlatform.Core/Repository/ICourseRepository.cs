
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();
        public Course? GetCourseById(int id);
        public void CreateCourse(Course course);
        public void UpdateCourse(Course course);
        public void DeleteCourse(int id);
    }
}
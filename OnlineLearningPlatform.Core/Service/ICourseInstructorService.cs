using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ICourseInstructorService
    {
        public List<CourseInstructor> GetAllCourseInstructors();
        public List<CourseInstructor> GetByCourseId(int courseId);
        public List<CourseInstructor> GetByInstructorId(int instructorId);
        public void CreateCourseInstructor(CourseInstructor courseInstructor);
        public void DeleteCourseInstructor(int courseId, int instructorId);
    }
}
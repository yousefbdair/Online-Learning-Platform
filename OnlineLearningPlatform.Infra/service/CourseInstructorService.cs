using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.Service
{
    public class CourseInstructorService : ICourseInstructorService
    {
        private readonly ICourseInstructorRepository courseInstructorRepository;
        public CourseInstructorService(ICourseInstructorRepository _courseInstructorRepository)
        {
            courseInstructorRepository = _courseInstructorRepository;
        }

        public List<CourseInstructor> GetAllCourseInstructors()
        {
            return courseInstructorRepository.GetAllCourseInstructors();
        }

        public List<CourseInstructor> GetByCourseId(int courseId)
        {
            return courseInstructorRepository.GetByCourseId(courseId);
        }

        public List<CourseInstructor> GetByInstructorId(int instructorId)
        {
            return courseInstructorRepository.GetByInstructorId(instructorId);
        }

        public void CreateCourseInstructor(CourseInstructor courseInstructor)
        {
            courseInstructorRepository.CreateCourseInstructor(courseInstructor);
        }

        public void DeleteCourseInstructor(int courseId, int instructorId)
        {
            courseInstructorRepository.DeleteCourseInstructor(courseId, instructorId);
        }
    }
}
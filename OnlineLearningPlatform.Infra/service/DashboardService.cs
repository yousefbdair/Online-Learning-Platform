using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.service
{
    public class DashboardService : IDashboardService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IInstructorRepository instructorRepository;
        private readonly IEnrollmentRepository enrollmentRepository;

        public DashboardService(
            ICourseRepository _courseRepository,
            IStudentRepository _studentRepository,
            IInstructorRepository _instructorRepository,
            IEnrollmentRepository _enrollmentRepository)
        {
            courseRepository = _courseRepository;
            studentRepository = _studentRepository;
            instructorRepository = _instructorRepository;
            enrollmentRepository = _enrollmentRepository;
        }

        public AdminStatsDto GetAdminStats()
        {
            return new AdminStatsDto
            {
                TotalCourses = courseRepository.GetAllCourses().Count,
                TotalStudents = studentRepository.GetAllStudent().Count,
                TotalInstructors = instructorRepository.GetAllInstructor().Count,
                TotalEnrollments = enrollmentRepository.GetAllEnrollments().Count
            };
        }

        public List<RecentEnrollmentDto> GetRecentEnrollments()
        {
            var enrollments = enrollmentRepository.GetAllEnrollments();
            var students = studentRepository.GetAllStudent();
            var courses = courseRepository.GetAllCourses();

            return enrollments
                .OrderByDescending(e => e.EnrollmentDate)
                .Take(5)
                .Select(e => new RecentEnrollmentDto
                {
                    StudentName = students.FirstOrDefault(s => s.StudentId == e.StudentId)?.Fullname ?? "Unknown",
                    CourseTitle = courses.FirstOrDefault(c => c.CourseId == e.CourseId)?.Title ?? "Unknown",
                    EnrollmentDate = e.EnrollmentDate,
                    Status = e.Status ?? ""
                })
                .ToList();
        }

        public List<PopularCourseDto> GetPopularCourses()
        {
            var enrollments = enrollmentRepository.GetAllEnrollments();
            var courses = courseRepository.GetAllCourses();

            return enrollments
                .Where(e => e.CourseId != null)
                .GroupBy(e => e.CourseId!.Value)
                .Select(g => new PopularCourseDto
                {
                    CourseId = g.Key,
                    Title = courses.FirstOrDefault(c => c.CourseId == g.Key)?.Title ?? "Unknown",
                    EnrollCount = g.Count()
                })
                .OrderByDescending(x => x.EnrollCount)
                .Take(5)
                .ToList();
        }
    }
}
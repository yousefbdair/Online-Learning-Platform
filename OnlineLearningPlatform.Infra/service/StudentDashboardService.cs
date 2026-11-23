using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.service
{
    public class StudentDashboardService : IStudentDashboardService
    {
        private readonly IEnrollmentRepository enrollmentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly ILessonRepository lessonRepository;
        private readonly ILessonProgressRepository progressRepository;
        private readonly ICourseInstructorRepository courseInstructorRepository;
        private readonly IInstructorRepository instructorRepository;

        public StudentDashboardService(
            IEnrollmentRepository _enrollmentRepository,
            ICourseRepository _courseRepository,
            ILessonRepository _lessonRepository,
            ILessonProgressRepository _progressRepository,
            ICourseInstructorRepository _courseInstructorRepository,
            IInstructorRepository _instructorRepository)
        {
            enrollmentRepository = _enrollmentRepository;
            courseRepository = _courseRepository;
            lessonRepository = _lessonRepository;
            progressRepository = _progressRepository;
            courseInstructorRepository = _courseInstructorRepository;
            instructorRepository = _instructorRepository;
        }

        public List<MyCourseDto> GetMyCourses(decimal studentId)
        {
            var enrollments = enrollmentRepository.GetAllEnrollments()
                .Where(e => e.StudentId == studentId)
                .ToList();

            var courses = courseRepository.GetAllCourses();
            var lessons = lessonRepository.GetAllLesson();
            var progress = progressRepository.GetAllProgress();
            var courseInstructors = courseInstructorRepository.GetAllCourseInstructors();
            var instructors = instructorRepository.GetAllInstructor();

            var result = new List<MyCourseDto>();

            foreach (var e in enrollments)
            {
                var course = courses.FirstOrDefault(c => c.CourseId == e.CourseId);
                if (course == null) continue;

                // دروس الكورس مرتبة
                var courseLessons = lessons
                    .Where(l => l.CourseId == course.CourseId)
                    .OrderBy(l => l.Lessonorder)
                    .ToList();

                // الدروس المكتملة لهذا التسجيل
                var completedIds = progress
                    .Where(p => p.EnrollmentId == e.EnrollmentId)
                    .Select(p => p.LessonId)
                    .ToHashSet();

                var completedCount = courseLessons.Count(l => completedIds.Contains(l.LessonId));
                var total = courseLessons.Count;

                var nextLesson = courseLessons.FirstOrDefault(l => !completedIds.Contains(l.LessonId));

                // أسماء المدرّسين (ممكن أكثر من واحد)
                var instructorNames = courseInstructors
                    .Where(ci => ci.CourseId == course.CourseId)
                    .Select(ci => instructors.FirstOrDefault(i => i.InstructorId == ci.InstructorId)?.Fullname)
                    .Where(n => !string.IsNullOrEmpty(n));

                result.Add(new MyCourseDto
                {
                    EnrollmentId = e.EnrollmentId,
                    CourseId = course.CourseId,
                    Title = course.Title,
                    ImageUrl = course.Imageurl,
                    Instructor = string.Join(", ", instructorNames),
                    EnrollmentDate = e.EnrollmentDate,
                    Status = e.Status ?? "",
                    TotalLessons = total,
                    CompletedLessons = completedCount,
                    ProgressPercent = total == 0 ? 0 : completedCount * 100 / total,
                    NextLessonId = nextLesson?.LessonId,
                    NextLessonTitle = nextLesson?.Title
                });
            }

            return result;
        }
    }
}
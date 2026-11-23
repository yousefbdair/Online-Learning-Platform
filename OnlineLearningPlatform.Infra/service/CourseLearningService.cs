using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.service
{
    public class CourseLearningService : ICourseLearningService
    {
        private readonly IEnrollmentRepository enrollmentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly ILessonRepository lessonRepository;
        private readonly ILessonProgressRepository progressRepository;

        public CourseLearningService(
            IEnrollmentRepository _enrollmentRepository,
            ICourseRepository _courseRepository,
            ILessonRepository _lessonRepository,
            ILessonProgressRepository _progressRepository)
        {
            enrollmentRepository = _enrollmentRepository;
            courseRepository = _courseRepository;
            lessonRepository = _lessonRepository;
            progressRepository = _progressRepository;
        }

        // تسجيل الطالب بالكورس (هاد اللي بيحمي المحتوى)
        private Enrollment? FindEnrollment(decimal studentId, decimal courseId)
        {
            return enrollmentRepository.GetAllEnrollments()
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public CourseLearningDto? GetCourseLearning(decimal studentId, decimal courseId)
        {
            var enrollment = FindEnrollment(studentId, courseId);
            if (enrollment == null) return null;

            var course = courseRepository.GetAllCourses()
                .FirstOrDefault(c => c.CourseId == courseId);
            if (course == null) return null;

            var lessons = lessonRepository.GetAllLesson()
                .Where(l => l.CourseId == courseId)
                .OrderBy(l => l.Lessonorder)
                .ToList();

            var progress = progressRepository.GetAllProgress()
                .Where(p => p.EnrollmentId == enrollment.EnrollmentId)
                .ToList();

            var lessonDtos = lessons.Select((l, index) =>
            {
                var done = progress.FirstOrDefault(p => p.LessonId == l.LessonId);
                return new LearningLessonDto
                {
                    LessonId = l.LessonId,
                    Title = l.Title,
                    Description = l.Description,
                    Order = l.Lessonorder ?? (index + 1),
                    IsCompleted = done != null,
                    CompletedAt = done?.CompletedAt
                };
            }).ToList();

            var completed = lessonDtos.Count(l => l.IsCompleted);
            var total = lessonDtos.Count;

            return new CourseLearningDto
            {
                CourseId = course.CourseId,
                CourseTitle = course.Title,
                EnrollmentId = enrollment.EnrollmentId,
                TotalLessons = total,
                CompletedLessons = completed,
                ProgressPercent = total == 0 ? 0 : completed * 100 / total,
                Lessons = lessonDtos
            };
        }

        public bool CompleteLesson(decimal studentId, decimal courseId, decimal lessonId)
        {
            var enrollment = FindEnrollment(studentId, courseId);
            if (enrollment == null) return false;

            // الدرس لازم يكون من نفس الكورس
            var lesson = lessonRepository.GetAllLesson()
                .FirstOrDefault(l => l.LessonId == lessonId && l.CourseId == courseId);
            if (lesson == null) return false;

            // إذا مكتمل أصلاً، ما نكرر (في كمان UNIQUE بالداتابيس)
            var alreadyDone = progressRepository.GetAllProgress()
                .Any(p => p.EnrollmentId == enrollment.EnrollmentId && p.LessonId == lessonId);
            if (alreadyDone) return true;

            progressRepository.CreateProgress(new Lessonprogress
            {
                EnrollmentId = enrollment.EnrollmentId,
                LessonId = lessonId,
                CompletedAt = DateTime.Now
            });

            return true;
        }
    }
}
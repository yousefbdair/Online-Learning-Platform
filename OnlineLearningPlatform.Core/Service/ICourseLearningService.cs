using OnlineLearningPlatform.Core.DTOs;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ICourseLearningService
    {
        // null = الطالب مش مسجّل بالكورس أو الكورس مش موجود
        CourseLearningDto? GetCourseLearning(decimal studentId, decimal courseId);

        // يرجّع false إذا مش مسجّل أو الدرس مش من هالكورس
        bool CompleteLesson(decimal studentId, decimal courseId, decimal lessonId);
    }
}
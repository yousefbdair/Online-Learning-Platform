using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ILessonProgressService
    {
        public List<Lessonprogress> GetAllLessonProgress();
        public List<Lessonprogress> GetProgressByEnrollmentId(int enrollmentId);
        public List<Lessonprogress> GetProgressByLessonId(int lessonId);
        public void CreateLessonProgress(Lessonprogress progress);
        public void UpdateLessonProgress(Lessonprogress progress);
        public void DeleteLessonProgress(int id);
        public Lessonprogress? GetLessonProgressById(int id);
    }
}
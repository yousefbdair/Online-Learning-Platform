using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.Service
{
    public class LessonProgressService : ILessonProgressService
    {
        private readonly ILessonProgressRepository lessonProgressRepository;
        public LessonProgressService(ILessonProgressRepository _lessonProgressRepository)
        {
            lessonProgressRepository = _lessonProgressRepository;
        }

        public List<Lessonprogress> GetAllLessonProgress()
        {
            return lessonProgressRepository.GetAllLessonProgress();
        }

        public List<Lessonprogress> GetProgressByEnrollmentId(int enrollmentId)
        {
            return lessonProgressRepository.GetProgressByEnrollmentId(enrollmentId);
        }

        public List<Lessonprogress> GetProgressByLessonId(int lessonId)
        {
            return lessonProgressRepository.GetProgressByLessonId(lessonId);
        }

        public void CreateLessonProgress(Lessonprogress progress)
        {
            lessonProgressRepository.CreateLessonProgress(progress);
        }

        public void UpdateLessonProgress(Lessonprogress progress)
        {
            lessonProgressRepository.UpdateLessonProgress(progress);
        }

        public void DeleteLessonProgress(int id)
        {
            lessonProgressRepository.DeleteLessonProgress(id);
        }

        public Lessonprogress? GetLessonProgressById(int id)
        {
            return lessonProgressRepository.GetLessonProgressById(id);
        }
    }
}
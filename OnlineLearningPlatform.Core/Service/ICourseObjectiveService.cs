using OnlineLearningPlatform.API.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ICourseObjectiveService
    {
        public List<Courseobjective> GetObjectivesByCourseId(int courseId);
        public void CreateCourseObjective(Courseobjective objective);
        public void UpdateCourseObjective(Courseobjective objective);
        public void DeleteCourseObjective(int id);
    }
}
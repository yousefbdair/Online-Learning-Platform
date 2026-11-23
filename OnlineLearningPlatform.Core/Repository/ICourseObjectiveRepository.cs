
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface ICourseObjectiveRepository
    {
        public List<Courseobjective> GetObjectivesByCourseId(int courseId);
        public void CreateCourseObjective(Courseobjective objective);
        public void UpdateCourseObjective(Courseobjective objective);
        public void DeleteCourseObjective(int id);
    }
}
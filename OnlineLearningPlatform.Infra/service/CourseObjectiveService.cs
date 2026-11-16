using OnlineLearningPlatform.API.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.Service
{
    public class CourseObjectiveService : ICourseObjectiveService
    {
        private readonly ICourseObjectiveRepository courseObjectiveRepository;
        public CourseObjectiveService(ICourseObjectiveRepository _courseObjectiveRepository)
        {
            courseObjectiveRepository = _courseObjectiveRepository;
        }

        public List<Courseobjective> GetObjectivesByCourseId(int courseId)
        {
            return courseObjectiveRepository.GetObjectivesByCourseId(courseId);
        }

        public void CreateCourseObjective(Courseobjective objective)
        {
            courseObjectiveRepository.CreateCourseObjective(objective);
        }

        public void UpdateCourseObjective(Courseobjective objective)
        {
            courseObjectiveRepository.UpdateCourseObjective(objective);
        }

        public void DeleteCourseObjective(int id)
        {
            courseObjectiveRepository.DeleteCourseObjective(id);
        }
    }
}
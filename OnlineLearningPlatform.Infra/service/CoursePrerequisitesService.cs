using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.Service
{
    public class CoursePrerequisitesService : ICoursePrerequisitesService
    {
        private readonly ICoursePrerequisitesRepository coursePrerequisitesRepository;
        public CoursePrerequisitesService(ICoursePrerequisitesRepository _coursePrerequisitesRepository)
        {
            coursePrerequisitesRepository = _coursePrerequisitesRepository;
        }

        public List<Courseprerequisite> GetAllCoursePrerequisites()
        {
            return coursePrerequisitesRepository.GetAllCoursePrerequisites();
        }

        public List<Courseprerequisite> GetPrerequisitesByCourseId(int courseId)
        {
            return coursePrerequisitesRepository.GetPrerequisitesByCourseId(courseId);
        }

        public void CreateCoursePrerequisite(Courseprerequisite prerequisite)
        {
            coursePrerequisitesRepository.CreateCoursePrerequisite(prerequisite);
        }

        public void UpdateCoursePrerequisite(Courseprerequisite prerequisite)
        {
            coursePrerequisitesRepository.UpdateCoursePrerequisite(prerequisite);
        }

        public void DeleteCoursePrerequisite(int id)
        {
            coursePrerequisitesRepository.DeleteCoursePrerequisite(id);
        }

        public Courseprerequisite? GetCoursePrerequisiteById(int id)
        {
            return coursePrerequisitesRepository.GetCoursePrerequisiteById(id);
        }
    }
}
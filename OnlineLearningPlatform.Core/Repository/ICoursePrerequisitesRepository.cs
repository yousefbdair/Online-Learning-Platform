using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface ICoursePrerequisitesRepository
    {
        public List<Courseprerequisite> GetAllCoursePrerequisites();
        public List<Courseprerequisite> GetPrerequisitesByCourseId(int courseId);
        public void CreateCoursePrerequisite(Courseprerequisite prerequisite);
        public void UpdateCoursePrerequisite(Courseprerequisite prerequisite);
        public void DeleteCoursePrerequisite(int id);
        public Courseprerequisite? GetCoursePrerequisiteById(int id);
    }
}
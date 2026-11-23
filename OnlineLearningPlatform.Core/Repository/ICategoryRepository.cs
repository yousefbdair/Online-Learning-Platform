
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
        public Category? GetCategoryById(int id);
    }
}

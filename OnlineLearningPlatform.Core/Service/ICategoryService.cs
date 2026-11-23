
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category? GetCategoryById(int id);
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
    }
}
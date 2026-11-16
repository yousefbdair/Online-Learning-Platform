using Dapper;
using OnlineLearningPlatform.API.Models;
using OnlineLearningPlatform.Core.Common;
using OnlineLearningPlatform.Core.Repository;
using System.Data;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext dbContext;
        public CategoryRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = dbContext.Connection.Query<Category>(
                "Category_PACKAGE.GETALLCATEGORIES",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCategory(Category category)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_CATEGORYNAME", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_DESCRIPTION", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("Category_PACKAGE.CreateCategory", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCategory(Category category)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", category.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_CATEGORYNAME", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_DESCRIPTION", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("Category_PACKAGE.UpdateCategory", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("Category_PACKAGE.DeleteCategory", parameter, commandType: CommandType.StoredProcedure);
        }

        public Category? GetCategoryById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = dbContext.Connection.Query<Category>(
                "Category_PACKAGE.GetCategoryById", parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
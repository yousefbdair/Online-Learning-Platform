using Dapper;

using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
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
                "CATEGORIES_PKG.GET_ALL",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCategory(Category category)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_NAME", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_DESC", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_ID", category.CategoryId, dbType: DbType.String, direction: ParameterDirection.Output);
            dbContext.Connection.Execute("CATEGORIES_PKG.ADD_CATEGORY", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCategory(Category category)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", category.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_NAME", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_DESC", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("CATEGORIES_PKG.UPDATE_CATEGORY", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("CATEGORIES_PKG.DELETE_CATEGORY", parameter, commandType: CommandType.StoredProcedure);
        }

        public Category? GetCategoryById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = dbContext.Connection.Query<Category>(
                "CATEGORIES_PKG.GET_BY_ID", parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
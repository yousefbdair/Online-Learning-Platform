using Dapper;

using OnlineLearningPlatform.Core.common;

using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Data;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext dbContext;
        public CourseRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Course> GetAllCourses()
        {
            IEnumerable<Course> result = dbContext.Connection.Query<Course>(
                "Course_PACKAGE.GetAllCourses",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCourse(Course course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_title", course.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_description", course.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_price", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Pac_duration", course.Duration, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Pac_imageurl", course.Imageurl, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_ispublished", course.IsPublished == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_isfeatured", course.IsFeatured == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_adminid", course.AdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_categoryid", course.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            dbContext.Connection.Execute("Course_PACKAGE.CreateCourse", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCourse(Course course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", course.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_title", course.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_description", course.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_price", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Pac_duration", course.Duration, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Pac_imageurl", course.Imageurl, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_ispublished", course.IsPublished == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_isfeatured", course.IsFeatured == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_adminid", course.AdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_categoryid", course.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("Course_PACKAGE.UpdateCourse", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourse(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("Course_PACKAGE.DeleteCourse", parameter, commandType: CommandType.StoredProcedure);
        }

        public Course? GetCourseById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dbContext.Connection.Query<Course>(
                "Course_PACKAGE.GetCourseById", parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
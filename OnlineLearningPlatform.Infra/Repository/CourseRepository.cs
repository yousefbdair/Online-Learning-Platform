using Dapper;
using OnlineLearningPlatform.API.Models;
using OnlineLearningPlatform.Core.Common;
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
                "Course_PACKAGE.GETALLCOURSES",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCourse(Course course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_TITLE", course.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_DESCRIPTION", course.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_PRICE", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("P_DURATION", course.Duration, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("P_IMAGEURL", course.Imageurl, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_IS_PUBLISHED", course.IsPublished == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_IS_FEATURED", course.IsFeatured == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_ADMIN_ID", course.AdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_CATEGORY_ID", course.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_INSTRUCTOR_ID", course.InstructorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("Course_PACKAGE.CreateCourse", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCourse(Course course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", course.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_TITLE", course.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_DESCRIPTION", course.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_PRICE", course.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("P_DURATION", course.Duration, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("P_IMAGEURL", course.Imageurl, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_IS_PUBLISHED", course.IsPublished == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_IS_FEATURED", course.IsFeatured == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_ADMIN_ID", course.AdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_CATEGORY_ID", course.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_INSTRUCTOR_ID", course.InstructorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("Course_PACKAGE.UpdateCourse", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourse(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("Course_PACKAGE.DeleteCourse", parameter, commandType: CommandType.StoredProcedure);
        }

        public Course? GetCourseById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dbContext.Connection.Query<Course>(
                "Course_PACKAGE.GetCourseById", parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
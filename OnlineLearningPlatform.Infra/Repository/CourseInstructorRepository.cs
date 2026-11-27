using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Data;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class CourseInstructorRepository : ICourseInstructorRepository
    {
        private readonly IDbContext dbContext;
        public CourseInstructorRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<CourseInstructor> GetAllCourseInstructors()
        {
            IEnumerable<CourseInstructor> result = dbContext.Connection.Query<CourseInstructor>(
                "COURSE_INSTRUCTOR_PKG.GET_ALL",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CourseInstructor> GetByCourseId(int courseId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_COURSE_ID", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CourseInstructor> result = dbContext.Connection.Query<CourseInstructor>(
                "COURSE_INSTRUCTOR_PKG.GET_BY_COURSE_ID", parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CourseInstructor> GetByInstructorId(int instructorId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_INSTRUCTOR_ID", instructorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CourseInstructor> result = dbContext.Connection.Query<CourseInstructor>(
                "COURSE_INSTRUCTOR_PKG.GET_BY_INSTRUCTOR_ID", parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCourseInstructor(CourseInstructor courseInstructor)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_INSTRUCTOR_ID", courseInstructor.InstructorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("p_COURSE_ID", courseInstructor.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("COURSE_INSTRUCTOR_PKG.add_course_instructor", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourseInstructor(int courseId, int instructorId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_INSTRUCTOR_ID", instructorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("p_COURSE_ID", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("COURSE_INSTRUCTOR_PKG.delete_course_instructor", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Data;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class CoursePrerequisitesRepository : ICoursePrerequisitesRepository
    {
        private readonly IDbContext dbContext;
        public CoursePrerequisitesRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Courseprerequisite> GetAllCoursePrerequisites()
        {
            IEnumerable<Courseprerequisite> result = dbContext.Connection.Query<Courseprerequisite>(
                "COURSEPREREQUISITES_PKG.GET_ALL",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Courseprerequisite> GetPrerequisitesByCourseId(int courseId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_COURSE_ID", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Courseprerequisite> result = dbContext.Connection.Query<Courseprerequisite>(
                "COURSEPREREQUISITES_PKG.GET_BY_COURSE", parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCoursePrerequisite(Courseprerequisite prerequisite)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_COURSE_ID", prerequisite.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_TEXT", prerequisite.PrerequisiteText, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_ID", prerequisite.PrerequisiteId, dbType: DbType.Int32, direction: ParameterDirection.Output);
            dbContext.Connection.Execute("COURSEPREREQUISITES_PKG.ADD_PREREQUISITE", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCoursePrerequisite(Courseprerequisite prerequisite)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", prerequisite.PrerequisiteId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_COURSE_ID", prerequisite.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_TEXT", prerequisite.PrerequisiteText, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("COURSEPREREQUISITES_PKG.UPDATE_PREREQUISITE", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCoursePrerequisite(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("COURSEPREREQUISITES_PKG.DELETE_PREREQUISITE", parameter, commandType: CommandType.StoredProcedure);
        }

        public Courseprerequisite? GetCoursePrerequisiteById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Courseprerequisite> result = dbContext.Connection.Query<Courseprerequisite>(
                "COURSEPREREQUISITES_PKG.GET_BY_ID", parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
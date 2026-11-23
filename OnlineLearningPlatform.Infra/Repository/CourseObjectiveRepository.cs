using Dapper;

using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Data;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class CourseObjectiveRepository : ICourseObjectiveRepository
    {
        private readonly IDbContext dbContext;
        public CourseObjectiveRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Courseobjective> GetObjectivesByCourseId(int courseId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_COURSE_ID", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Courseobjective> result = dbContext.Connection.Query<Courseobjective>(
                "CourseObjective_PACKAGE.GetObjectivesByCourseId", parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCourseObjective(Courseobjective objective)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_COURSE_ID", objective.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_OBJECTIVE_TEXT", objective.ObjectiveText, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("CourseObjective_PACKAGE.CreateCourseObjective", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCourseObjective(Courseobjective objective)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", objective.ObjectiveId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_COURSE_ID", objective.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_OBJECTIVE_TEXT", objective.ObjectiveText, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("CourseObjective_PACKAGE.UpdateCourseObjective", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourseObjective(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("CourseObjective_PACKAGE.DeleteCourseObjective", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
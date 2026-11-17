using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Data;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class LessonProgressRepository : ILessonProgressRepository
    {
        private readonly IDbContext dbContext;
        public LessonProgressRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Lessonprogress> GetAllLessonProgress()
        {
            IEnumerable<Lessonprogress> result = dbContext.Connection.Query<Lessonprogress>(
                "LessonProgress_PACKAGE.GETALLLESSONPROGRESS",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Lessonprogress> GetProgressByEnrollmentId(int enrollmentId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ENROLLMENT_ID", enrollmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Lessonprogress> result = dbContext.Connection.Query<Lessonprogress>(
                "LessonProgress_PACKAGE.GetProgressByEnrollmentId", parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Lessonprogress> GetProgressByLessonId(int lessonId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_LESSON_ID", lessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Lessonprogress> result = dbContext.Connection.Query<Lessonprogress>(
                "LessonProgress_PACKAGE.GetProgressByLessonId", parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateLessonProgress(Lessonprogress progress)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_COMPLETED_AT", progress.CompletedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("P_LESSON_ID", progress.LessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_ENROLLMENT_ID", progress.EnrollmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("LessonProgress_PACKAGE.CreateLessonProgress", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateLessonProgress(Lessonprogress progress)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", progress.ProgressId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_COMPLETED_AT", progress.CompletedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("P_LESSON_ID", progress.LessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_ENROLLMENT_ID", progress.EnrollmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("LessonProgress_PACKAGE.UpdateLessonProgress", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLessonProgress(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("LessonProgress_PACKAGE.DeleteLessonProgress", parameter, commandType: CommandType.StoredProcedure);
        }

        public Lessonprogress? GetLessonProgressById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Lessonprogress> result = dbContext.Connection.Query<Lessonprogress>(
                "LessonProgress_PACKAGE.GetLessonProgressById", parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
using System;
using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class LessonProgressRepository : ILessonProgressRepository

    {
        private readonly IDbContext dbcontext;

        public LessonProgressRepository(IDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public List<Lessonprogress> GetAllProgress()
        {
            IEnumerable<Lessonprogress> result = dbcontext.Connection.Query<Lessonprogress>(
                "LessonProgress_PACKAGE.GetAllProgress",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateProgress(Lessonprogress progress)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_lessonid", progress.LessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_enrollmentid", progress.EnrollmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("LessonProgress_PACKAGE.CreateProgress", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateProgress(Lessonprogress progress)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", progress.ProgressId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_completedat", progress.CompletedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("Pac_lessonid", progress.LessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_enrollmentid", progress.EnrollmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("LessonProgress_PACKAGE.UpdateProgress", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteProgress(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("LessonProgress_PACKAGE.DeleteProgress", parameter, commandType: CommandType.StoredProcedure);
        }

        public Lessonprogress GetProgressById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Lessonprogress> result = dbcontext.Connection.Query<Lessonprogress>(
                "LessonProgress_PACKAGE.GetProgressById",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}


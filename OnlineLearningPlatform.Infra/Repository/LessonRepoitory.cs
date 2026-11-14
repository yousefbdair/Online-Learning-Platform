using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class LessonRepository: ILessonRepository    
    {
        private readonly IDbContext dbcontext;

        public LessonRepository(IDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public List<Lesson> GetAllLesson()
        {
            IEnumerable<Lesson> result = dbcontext.Connection.Query<Lesson>(
                "Lesson_PACKAGE.GetAllLessons",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateLesson(Lesson lesson)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_title", lesson.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_description", lesson.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_lessonorder", lesson.Lessonorder, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_courseid", lesson.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Lesson_PACKAGE.CreateLesson", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateLesson(Lesson lesson)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", lesson.LessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_title", lesson.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_description", lesson.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_lessonorder", lesson.Lessonorder, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_courseid", lesson.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Lesson_PACKAGE.UpdateLesson", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLesson(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Lesson_PACKAGE.DeleteLesson", parameter, commandType: CommandType.StoredProcedure);
        }

        public Lesson GetLessonById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Lesson> result = dbcontext.Connection.Query<Lesson>(
                "Lesson_PACKAGE.GetLessonById",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Lesson> GetLessonsByCourse(int courseId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_courseid", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Lesson> result = dbcontext.Connection.Query<Lesson>(
                "Lesson_PACKAGE.GetLessonsByCourse",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
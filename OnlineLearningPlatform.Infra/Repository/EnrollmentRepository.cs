using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly IDbContext dbcontext;

        public EnrollmentRepository(IDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public List<Enrollment> GetAllEnrollments()
        {
            IEnumerable<Enrollment> result = dbcontext.Connection.Query<Enrollment>(
                "Enrollment_PACKAGE.GetAllEnrollments",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateEnrollment(Enrollment enrollment)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_feepaid", enrollment.FeePaid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Pac_status", enrollment.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_courseid", enrollment.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_studentid", enrollment.StudentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Enrollment_PACKAGE.CreateEnrollment", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", enrollment.EnrollmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_feepaid", enrollment.FeePaid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Pac_status", enrollment.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_courseid", enrollment.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_studentid", enrollment.StudentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Enrollment_PACKAGE.UpdateEnrollment", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteEnrollment(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Enrollment_PACKAGE.DeleteEnrollment", parameter, commandType: CommandType.StoredProcedure);
        }

        public Enrollment GetEnrollmentById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Enrollment> result = dbcontext.Connection.Query<Enrollment>(
                "Enrollment_PACKAGE.GetEnrollmentById",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Enrollment> GetEnrollmentsByStudent(int studentId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_studentid", studentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Enrollment> result = dbcontext.Connection.Query<Enrollment>(
                "Enrollment_PACKAGE.GetEnrollmentsByStudent",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Enrollment> GetEnrollmentsByCourse(int courseId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_courseid", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Enrollment> result = dbcontext.Connection.Query<Enrollment>(
                "Enrollment_PACKAGE.GetEnrollmentsByCourse",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
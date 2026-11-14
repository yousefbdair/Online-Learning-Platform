using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private IDbContext dbcontext;
        public InstructorRepository(IDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public List<Instructor> GetAllInstructor()
        {
            IEnumerable<Instructor> result = dbcontext.Connection.Query<Instructor>("INSTRUCTOR_PKG.GET_ALL",
                commandType: CommandType.StoredProcedure);
            return result.ToList(); 
        }
        public Instructor GetInstructorById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Instructor> result = dbcontext.Connection.Query<Instructor>("INSTRUCTOR_PKG.GET_BY_ID",
                parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public void CreateInstructor(Instructor instructor)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID",instructor.InstructorId, dbType:DbType.Int32,direction:ParameterDirection.Output);
            parameter.Add("P_NAME", instructor.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_EMAIL", instructor.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_BIO", instructor.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("INSTRUCTOR_PKG.ADD_INSTRUCTOR", parameter, commandType: CommandType.StoredProcedure);
        }
        public void UpdateInstructor(Instructor instructor)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", instructor.InstructorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P_NAME", instructor.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_EMAIL", instructor.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_BIO", instructor.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("INSTRUCTOR_PKG.UPDATE_INSTRUCTOR", parameter, commandType: CommandType.StoredProcedure);
        }
        public void DeleteInstructor(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID",id, dbType: DbType.Int32, direction:ParameterDirection.Input);
            dbcontext.Connection.Execute("INSTRUCTOR_PKG.DELETE_INSTRUCTOR", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}

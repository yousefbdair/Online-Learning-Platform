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
    public class StudentRepository: IStudentRepository
    {
        private IDbContext dbcontext;
        public StudentRepository(IDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public List<Student> GetAllStudent()
        {
            IEnumerable<Student> result = dbcontext.Connection.Query<Student>("Students_PACKAGE.GetAllStudents",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateStudent(Student student)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_fullname",student.Fullname,dbType:DbType.String,direction:ParameterDirection.Input);
            parameter.Add("Pac_email", student.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_password", student.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_phone", student.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Students_PACKAGE.CreateStudent", parameter, commandType: CommandType.StoredProcedure);
        }
        public void UpdateStudent(Student student)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id",student.StudentId,dbType:DbType.Int32,direction:ParameterDirection.Input);
            parameter.Add("Pac_fullname", student.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_email", student.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_password", student.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Pac_phone", student.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Students_PACKAGE.UpdateStudent", parameter, commandType: CommandType.StoredProcedure);
        }
        public void DeleteStudent(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id",id,dbType:DbType.Int32,direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("Students_PACKAGE.DeleteStudent", parameter, commandType: CommandType.StoredProcedure);
        }
        public Student GetStudentById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dbcontext.Connection.Query<Student>("Students_PACKAGE.GetStudentById",
                parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}

using OnlineLearningPlatform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudent();
        public void CreateStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
        public Student GetStudentById(int id);
    }
}

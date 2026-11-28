using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Infra.service
{
    public class StudentService: IStudentService
    {
        private IStudentRepository studentRepository;
        public StudentService(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public List<Student> GetAllStudent()
        {
            return studentRepository.GetAllStudent();
        }
        public void CreateStudent(Student student)
        {
            student.Password = HashIfNeeded(student.Password);
            studentRepository.CreateStudent(student);
        }
        public void UpdateStudent(Student student)
        {
            student.Password = HashIfNeeded(student.Password);
            studentRepository.UpdateStudent(student);
        }
        public void DeleteStudent(int id)
        {
            studentRepository.DeleteStudent(id);
        }
        public Student GetStudentById(int id)
        {
            return studentRepository.GetStudentById(id);
        }
        private static string HashIfNeeded(string password) =>
    password.StartsWith("$2") ? password : BCrypt.Net.BCrypt.HashPassword(password);
    }
}

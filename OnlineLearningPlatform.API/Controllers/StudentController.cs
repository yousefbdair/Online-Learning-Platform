using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using OnlineLearningPlatform.Infra.Repository;
using OnlineLearningPlatform.Infra.service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService _studentService)
        {
           studentService = _studentService;
        }
        [HttpGet]
        public List<Student> GetAllStudent()
        {
            return studentService.GetAllStudent();
        }
        [HttpPost]
        public void CreateStudent(Student student)
        {
            studentService.CreateStudent(student);
        }
        [HttpPut]
        public void UpdateStudent(Student student)
        {
            studentService.UpdateStudent(student);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteStudent(int id)
        {
            studentService.DeleteStudent(id);
        }
        [HttpGet]
        [Route("Getstudent/{id}")]
        public Student GetStudentById(int id)
        {
            return studentService.GetStudentById(id);
        }
    }
}

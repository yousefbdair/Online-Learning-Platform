using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;
using OnlineLearningPlatform.Core.Repository;


namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService enrollmentService;
        public EnrollmentController(IEnrollmentService _enrollmentService)
        {
            enrollmentService = _enrollmentService;
        }
        [HttpGet]
        public List<Enrollment> GetAllEnrollments()
        {
            return enrollmentService.GetAllEnrollments();
        }
        [HttpGet]
        [Route("getenrollment/{id}")]
        public Enrollment GetEnrollmentById(int id)
        {
            return enrollmentService.GetEnrollmentById(id);
        }
        [HttpGet]
        [Route("getbystudent/{studentId}")]
        public List<Enrollment> GetEnrollmentsByStudent(int studentId)
        {
            return enrollmentService.GetEnrollmentsByStudent(studentId);
        }
        [HttpGet]
        [Route("getbycourse/{courseId}")]
        public List<Enrollment> GetEnrollmentsByCourse(int courseId)
        {
            return enrollmentService.GetEnrollmentsByCourse(courseId);
        }
        [HttpPost]
        public void CreateEnrollment(Enrollment enrollment)
        {
            enrollmentService.CreateEnrollment(enrollment);
        }
        [HttpPut]
        public void UpdateEnrollment(Enrollment enrollment)
        {
            enrollmentService.UpdateEnrollment(enrollment);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteEnrollment(int id)
        {
            enrollmentService.DeleteEnrollment(id);
        }
    }
}

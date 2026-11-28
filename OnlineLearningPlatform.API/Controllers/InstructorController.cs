using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using OnlineLearningPlatform.Infra.service;


namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private IInstructorService instructorService;
        public InstructorController(IInstructorService _instructorService)
        {
            instructorService = _instructorService;
        }
        [HttpGet]
        public List<Instructor> GetAllInstructor()
        {
            return instructorService.GetAllInstructor();
        }
        [HttpGet]
        [Route("getinstructor /{id}")]
        public Instructor GetInstructorById(int id)
        {
            return instructorService.GetInstructorById(id);
        }
        /*[HttpPost]
        public void CreateInstructor(Instructor instructor)
        {
            instructorService.CreateInstructor(instructor);
        }*/
        [HttpPut]
        public void UpdateInstructor(Instructor instructor)
        {
            instructorService.UpdateInstructor(instructor);
        }
        [HttpDelete]
        [Route("deleteinstructor/{id}")]
        public void DeleteInstructor(int id)
        {
            instructorService.DeleteInstructor(id);
        }
        [HttpPost]
        
        public IActionResult Create([FromBody] Instructor instructor)
        {
            try
            {
                instructorService.CreateInstructor(instructor);
                return Ok(new { message = "تم إضافة المدرس بنجاح." });
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }
}

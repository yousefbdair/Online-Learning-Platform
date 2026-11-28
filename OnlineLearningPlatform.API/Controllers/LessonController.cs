using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService lessonService;
        public LessonController(ILessonService _lessonService)
        {
            lessonService = _lessonService;
        }
        [HttpGet]
        public List<Lesson> GetAllLesson()
        {
            return lessonService.GetAllLesson();
        }
        [HttpGet]
        [Route("getlesson/{id}")]
        public Lesson GetLessonById(int id)
        {
            return lessonService.GetLessonById(id);
        }
        [HttpGet]
        [Route("getbycourse/{courseId}")]
        public List<Lesson> GetLessonsByCourse(int courseId)
        {
            return lessonService.GetLessonsByCourse(courseId);
        }
        [HttpPost]
        public void CreateLesson(Lesson lesson)
        {
            lessonService.CreateLesson(lesson);
        }
        [HttpPut]
        public void UpdateLesson(Lesson lesson)
        {
            lessonService.UpdateLesson(lesson);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteLesson(int id)
        {
            lessonService.DeleteLesson(id);
        }
    }
}



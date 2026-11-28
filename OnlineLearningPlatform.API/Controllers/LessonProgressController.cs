using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonProgressController : ControllerBase
    {
        private readonly ILessonProgressService lessonProgressService;
        public LessonProgressController(ILessonProgressService _lessonProgressService)
        {
            lessonProgressService = _lessonProgressService;
        }
        [HttpGet]
        public List<Lessonprogress> GetAllProgress()
        {
            return lessonProgressService.GetAllProgress();
        }
        [HttpGet]
        [Route("getprogress/{id}")]
        public Lessonprogress GetProgressById(int id)
        {
            return lessonProgressService.GetProgressById(id);
        }
        [HttpPost]
        public void CreateProgress(Lessonprogress progress)
        {
            lessonProgressService.CreateProgress(progress);
        }
        [HttpPut]
        public void UpdateProgress(Lessonprogress progress)
        {
            lessonProgressService.UpdateProgress(progress);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteProgress(int id)
        {
            lessonProgressService.DeleteProgress(id);
        }
    }
}


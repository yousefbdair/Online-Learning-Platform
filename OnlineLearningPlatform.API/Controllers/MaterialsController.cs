using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialsService materialsService;
        public MaterialsController(IMaterialsService _materialsService)
        {
            materialsService = _materialsService;
        }
        [HttpGet]
        public List<Material> GetAllMaterial()
        {
            return materialsService.GetAllMaterial();
        }
        [HttpGet]
        [Route("getmaterial/{id}")]
        public Material GetById(int id)
        {
            return materialsService.GetById(id);
        }
        [HttpGet]
        [Route("getbylesson/{lessonId}")]
        public List<Material> GetMaterialsByLesson(int lessonId)
        {
            return materialsService.GetMaterialsByLesson(lessonId);
        }
        [HttpPost]
        public void CreateMaterial(Material material)
        {
            materialsService.CreateMaterial(material);
        }
        [HttpPut]
        public void UpdateMaterial(Material material)
        {
            materialsService.UpdateMaterial(material);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteMaterial(int id)
        {
            materialsService.DeleteMaterial(id);
        }
    }
}

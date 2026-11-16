using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.Service
{
    public class MaterialsService : IMaterialsService
    {
        private readonly IMaterialsRepository materialsRepository;
        public MaterialsService(IMaterialsRepository _materialsRepository)
        {
            materialsRepository = _materialsRepository;
        }
        public List<Material> GetAllMaterial()
        {
            return materialsRepository.GetAllMaterial();
        }
        public void CreateMaterial(Material material)
        {
            materialsRepository.CreateMaterial(material);
        }
        public void UpdateMaterial(Material material)
        {
            materialsRepository.UPDATEMATERIAL(material);
        }
        public void DeleteMaterial(int id)
        {
            materialsRepository.DELETE_MATERIAL(id);
        }
        public Material GetById(int id)
        {
            return materialsRepository.GetById(id);
        }
        public List<Material> GetMaterialsByLesson(int lessonId)
        {
            return materialsRepository.GetMaterialsByLesson(lessonId);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;


namespace OnlineLearningPlatform.Core.Service
{
    public interface IMaterialsService
    {
        public List<Material> GetAllMaterial();
        public void CreateMaterial(Material material);
        public void UpdateMaterial(Material material);
        public void DeleteMaterial(int id);
        public Material GetById(int id);
        public List<Material> GetMaterialsByLesson(int lessonId);
    }
}


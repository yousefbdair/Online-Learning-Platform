using OnlineLearningPlatform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface IMaterialsRepository
    {
        public List<Material> GetAllMaterial();
        public void CreateMaterial(Material material);
        public void UPDATEMATERIAL(Material material);
        public void DELETE_MATERIAL(int id);
        public Material GetById(int id);
        public List<Material> GetMaterialsByLesson(int lessonId);

    }
}

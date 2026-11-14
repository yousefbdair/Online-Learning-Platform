using Dapper;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly IDbContext dbcontext;

        public MaterialsRepository(IDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public List<Material> GetAllMaterial()
        {
            IEnumerable<Material> result = dbcontext.Connection.Query<Material>(
                "MATERIALS_PKG.GET_ALL",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateMaterial(Material material)
        {
            var parameter = new DynamicParameters();
            parameter.Add("(P_LESSON_ID", material.LessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_title", material.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_URL", material.MaterialUrl, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_ID", material.MaterialId, dbType: DbType.Int32, direction: ParameterDirection.Output);
            dbcontext.Connection.Execute("MATERIALS_PKG.ADD_MATERIAL", parameter, commandType: CommandType.StoredProcedure);
        }
        public void UPDATEMATERIAL(Material material)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", material.MaterialId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("(P_LESSON_ID", material.LessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Pac_title", material.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("P_URL", material.MaterialUrl, dbType: DbType.String, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("MATERIALS_PKG.UPDATE_MATERIAL ", parameter, commandType: CommandType.StoredProcedure);
        }
        public void DELETE_MATERIAL(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("MATERIALS_PKG.DELETE_MATERIAL ", parameter, commandType: CommandType.StoredProcedure);
        }

        public Material GetById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Pac_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Material> result = dbcontext.Connection.Query<Material>(
                "MATERIALS_PKG.GET_BY_ID",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Material> GetMaterialsByLesson(int lessonId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("P_LESSON_ID", lessonId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Material> result = dbcontext.Connection.Query<Material>(
                "MATERIALS_PKG.GET_BY_LESSON",
                parameter,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}

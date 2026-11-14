using Dapper;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Core.common;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Infra.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Infra.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private IDbContext dbcontext;

        public AdminRepository(IDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public List<Admin> GetAllAdmin()
        {
            IEnumerable<Admin> result = dbcontext.Connection.Query<Admin>("ADMIN_PKG.GET_ALL",
                       commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Admin GetAdminById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Admin> result = dbcontext.Connection.Query<Admin>("ADMIN_PKG.GET_BY_ID", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public void CreateAdmin(Admin admin)
        {
            var parameter = new DynamicParameters();
            parameter.Add("NAME", admin.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("p_EMAIL", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("PASS", admin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            //parameter.Add("CREATED_AT", admin.CreatedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("AD_ID", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            dbcontext.Connection.Execute("ADMIN_PKG.add_admin", parameter, commandType: CommandType.StoredProcedure);
        }
        public void UpdateAdmin(Admin admin)
        {
            var parameter = new DynamicParameters();
            parameter.Add("NAME", admin.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("p_EMAIL", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("PASS", admin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            //parameter.Add("CREATED_AT", admin.CreatedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("AD_ID", admin.AdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("ADMIN_PKG.update_admin", parameter, commandType: CommandType.StoredProcedure);
        }
        public void DeleteAdmin(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbcontext.Connection.Execute("ADMIN_PKG.delete_admin", parameter, commandType: CommandType.StoredProcedure);
        }
        
    }
}

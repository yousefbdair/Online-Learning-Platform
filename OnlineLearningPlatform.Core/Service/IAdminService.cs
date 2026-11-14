using OnlineLearningPlatform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Core.Service
{
    public interface IAdminService
    {
        public List<Admin> GetAllAdmin();
        public Admin GetAdminById(int id);
        public void CreateAdmin(Admin admin);
        public void UpdateAdmin(Admin admin);
        public void DeleteAdmin(int id);
    }
}

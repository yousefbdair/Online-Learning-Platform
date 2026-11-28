using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Infra.service
{
    public class AdminService : IAdminService
    {
        private IAdminRepository adminRepository;
        public AdminService(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;
        }
        public List<Admin> GetAllAdmin()
        {
            return adminRepository.GetAllAdmin();
        }
        public Admin GetAdminById(int id)
        {
            return adminRepository.GetAdminById(id); 
        }
        public void CreateAdmin(Admin admin)
        {
            admin.Password = HashIfNeeded(admin.Password);
            adminRepository.CreateAdmin(admin);
        }
        public void UpdateAdmin(Admin admin)
        {
            admin.Password = HashIfNeeded(admin.Password);
            adminRepository.UpdateAdmin(admin);
        }
        public void DeleteAdmin(int id)
        {
            adminRepository.DeleteAdmin(id);
        }
        private static string HashIfNeeded(string password) =>
    password.StartsWith("$2") ? password : BCrypt.Net.BCrypt.HashPassword(password);
    }
}

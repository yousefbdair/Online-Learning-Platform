using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using OnlineLearningPlatform.Infra.Repository;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        [HttpGet]
        public List<Admin> GetAllAdmin()
        {
            return adminService.GetAllAdmin();
        }
        [HttpGet]
        [Route("getadmin/{id}")]
        public Admin GetAdminById(int id)
        {
            return adminService.GetAdminById(id);
        }
        [HttpPost]
        public void CreateAdmin(Admin admin)
        {
            adminService.CreateAdmin(admin);
        }
        [HttpPut]
        public void UpdateAdmin(Admin admin)
        {
            adminService.UpdateAdmin(admin);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteAdmin(int id)
        {
            adminService.DeleteAdmin(id);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpPost("admin-login")]
        public IActionResult AdminLogin(LoginDto dto)
        {
            var result = authService.AdminLogin(dto);
            if (result == null)
                return Unauthorized("Invalid email or password");
            return Ok(result);
        }

        [HttpPost("student-login")]
        public IActionResult StudentLogin(LoginDto dto)
        {
            var result = authService.StudentLogin(dto);
            if (result == null)
                return Unauthorized("Invalid email or password");
            return Ok(result);
        }
    }
}
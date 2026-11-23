using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineLearningPlatform.Core.DTOs;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineLearningPlatform.Infra.service
{
    public class AuthService : IAuthService
    {
        private readonly IAdminRepository adminRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IConfiguration config;

        public AuthService(
            IAdminRepository _adminRepository,
            IStudentRepository _studentRepository,
            IConfiguration _config)
        {
            adminRepository = _adminRepository;
            studentRepository = _studentRepository;
            config = _config;
        }

        public LoginResponseDto? AdminLogin(LoginDto dto)
        {
            var admin = adminRepository.GetAllAdmin()
                .FirstOrDefault(a => a.Email.ToLower() == dto.Email.ToLower());

            if (admin == null || !PasswordMatches(dto.Password, admin.Password))
                return null;

            return new LoginResponseDto
            {
                Token = CreateToken(admin.AdminId, admin.Email, "Admin"),
                Role = "Admin",
                UserId = admin.AdminId,
                FullName = admin.Fullname
            };
        }

        public LoginResponseDto? StudentLogin(LoginDto dto)
        {
            var student = studentRepository.GetAllStudent()
                .FirstOrDefault(s => s.Email.ToLower() == dto.Email.ToLower());

            if (student == null || !PasswordMatches(dto.Password, student.Password))
                return null;

            return new LoginResponseDto
            {
                Token = CreateToken(student.StudentId, student.Email, "Student"),
                Role = "Student",
                UserId = student.StudentId,
                FullName = student.Fullname
            };
        }

        
        private bool PasswordMatches(string entered, string stored)
        {
            if (stored.StartsWith("$2"))
                return BCrypt.Net.BCrypt.Verify(entered, stored);

            return entered == stored; 
        }

        private string CreateToken(decimal id, string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
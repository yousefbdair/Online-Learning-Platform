using OnlineLearningPlatform.Core.DTOs;

namespace OnlineLearningPlatform.Core.Service
{
    public interface IAuthService
    {
        LoginResponseDto? AdminLogin(LoginDto dto);
        LoginResponseDto? StudentLogin(LoginDto dto);
    }
}
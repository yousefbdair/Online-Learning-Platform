namespace OnlineLearningPlatform.Core.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class LoginResponseDto
    {
        public string Token { get; set; } = "";
        public string Role { get; set; } = "";
        public decimal UserId { get; set; }
        public string FullName { get; set; } = "";
    }
}
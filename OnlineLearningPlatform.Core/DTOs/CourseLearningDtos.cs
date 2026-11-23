namespace OnlineLearningPlatform.Core.DTOs
{
    public class LearningLessonDto
    {
        public decimal LessonId { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public int Order { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    public class CourseLearningDto
    {
        public decimal CourseId { get; set; }
        public string CourseTitle { get; set; } = "";
        public decimal EnrollmentId { get; set; }
        public int TotalLessons { get; set; }
        public int CompletedLessons { get; set; }
        public int ProgressPercent { get; set; }
        public List<LearningLessonDto> Lessons { get; set; } = new();
    }
}
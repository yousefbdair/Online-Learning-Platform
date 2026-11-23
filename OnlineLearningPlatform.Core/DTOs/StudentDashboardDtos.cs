using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Core.DTOs
{
    public class MyCourseDto
    {
        public decimal EnrollmentId { get; set; }
        public decimal CourseId { get; set; }
        public string Title { get; set; } = "";
        public string? ImageUrl { get; set; }
        public string Instructor { get; set; } = "";
        public DateTime? EnrollmentDate { get; set; }
        public string Status { get; set; } = "";
        public int TotalLessons { get; set; }
        public int CompletedLessons { get; set; }
        public int ProgressPercent { get; set; }
        public decimal? NextLessonId { get; set; }
        public string? NextLessonTitle { get; set; }
    }
}
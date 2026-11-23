using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Core.DTOs
{
    public class AdminStatsDto
    {
        public int TotalCourses { get; set; }
        public int TotalStudents { get; set; }
        public int TotalEnrollments { get; set; }
        public int TotalInstructors { get; set; }
    }

    public class RecentEnrollmentDto
    {
        public string StudentName { get; set; } = "";
        public string CourseTitle { get; set; } = "";
        public DateTime? EnrollmentDate { get; set; }
        public string Status { get; set; } = "";
    }

    public class PopularCourseDto
    {
        public decimal CourseId { get; set; }
        public string Title { get; set; } = "";
        public int EnrollCount { get; set; }
    }
}

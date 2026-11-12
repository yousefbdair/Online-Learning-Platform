using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Instructor
{
    public decimal InstructorId { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Bio { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Enrollment
{
    public decimal EnrollmentId { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public decimal? FeePaid { get; set; }

    public string? Status { get; set; }

    public decimal? CourseId { get; set; }

    public decimal? StudentId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Lessonprogress> Lessonprogresses { get; set; } = new List<Lessonprogress>();

    public virtual Student? Student { get; set; }
}

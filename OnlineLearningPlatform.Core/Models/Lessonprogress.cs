using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Lessonprogress
{
    public decimal ProgressId { get; set; }

    public DateTime? CompletedAt { get; set; }

    public decimal LessonId { get; set; }

    public decimal EnrollmentId { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual Lesson Lesson { get; set; } = null!;
}

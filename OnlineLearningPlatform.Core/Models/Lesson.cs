using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Lesson
{
    public decimal LessonId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public short? Lessonorder { get; set; }

    public decimal CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Lessonprogress> Lessonprogresses { get; set; } = new List<Lessonprogress>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}

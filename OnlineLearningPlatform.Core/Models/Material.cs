using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Material
{
    public decimal MaterialId { get; set; }

    public decimal LessonId { get; set; }

    public string Title { get; set; } = null!;

    public string MaterialUrl { get; set; } = null!;

    public virtual Lesson Lesson { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Courseobjective
{
    public decimal ObjectiveId { get; set; }

    public decimal CourseId { get; set; }

    public string ObjectiveText { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}

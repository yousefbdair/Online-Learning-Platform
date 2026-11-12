using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Courseprerequisite
{
    public decimal PrerequisiteId { get; set; }

    public decimal CourseId { get; set; }

    public string PrerequisiteText { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}

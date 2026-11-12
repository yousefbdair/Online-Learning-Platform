using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Category
{
    public decimal CategoryId { get; set; }

    public string Categoryname { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

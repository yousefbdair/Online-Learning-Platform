using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Admin
{
    public decimal AdminId { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

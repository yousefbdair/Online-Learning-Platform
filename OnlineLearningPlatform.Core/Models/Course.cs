using System;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Models;

public partial class Course
{
    public decimal CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? Duration { get; set; }

    public string? Imageurl { get; set; }

    public bool? IsPublished { get; set; }

    public bool? IsFeatured { get; set; }

    public DateTime? CreatedAt { get; set; }

    public decimal? AdminId { get; set; }

    public decimal? CategoryId { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Courseobjective> Courseobjectives { get; set; } = new List<Courseobjective>();

    public virtual ICollection<Courseprerequisite> Courseprerequisites { get; set; } = new List<Courseprerequisite>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
}

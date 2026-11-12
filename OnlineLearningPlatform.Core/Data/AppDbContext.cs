using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Courseobjective> Courseobjectives { get; set; }

    public virtual DbSet<Courseprerequisite> Courseprerequisites { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Lessonprogress> Lessonprogresses { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=localhost:1521/XEPDB1;User Id=OnlineLearningPlatform;Password=1125;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ONLINELEARNINGPLATFORM")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("SYS_C008240");

            entity.ToTable("ADMIN");

            entity.HasIndex(e => e.Email, "SYS_C008241").IsUnique();

            entity.Property(e => e.AdminId)
                .HasColumnType("NUMBER")
                .HasColumnName("ADMIN_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("SYS_C008249");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.CategoryId)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("SYS_C008262");

            entity.ToTable("COURSE");

            entity.Property(e => e.CourseId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.AdminId)
                .HasColumnType("NUMBER")
                .HasColumnName("ADMIN_ID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Duration)
                .HasColumnType("NUMBER")
                .HasColumnName("DURATION");
            entity.Property(e => e.Imageurl)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("IMAGEURL");
            entity.Property(e => e.InstructorId)
                .HasColumnType("NUMBER")
                .HasColumnName("INSTRUCTOR_ID");
            entity.Property(e => e.IsFeatured)
                .IsRequired()
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("IS_FEATURED");
            entity.Property(e => e.IsPublished)
                .IsRequired()
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("IS_PUBLISHED");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER")
                .HasColumnName("PRICE");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Admin).WithMany(p => p.Courses)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_COURSE_ADMIN");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_COURSE_CATEGORY");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_COURSE_INSTRUCTOR");
        });

        modelBuilder.Entity<Courseobjective>(entity =>
        {
            entity.HasKey(e => e.ObjectiveId).HasName("SYS_C008273");

            entity.ToTable("COURSEOBJECTIVES");

            entity.Property(e => e.ObjectiveId)
                .HasColumnType("NUMBER")
                .HasColumnName("OBJECTIVE_ID");
            entity.Property(e => e.CourseId)
                .HasColumnType("NUMBER")
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.ObjectiveText)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("OBJECTIVE_TEXT");

            entity.HasOne(d => d.Course).WithMany(p => p.Courseobjectives)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("HAS_OBJECTIVE");
        });

        modelBuilder.Entity<Courseprerequisite>(entity =>
        {
            entity.HasKey(e => e.PrerequisiteId).HasName("SYS_C008277");

            entity.ToTable("COURSEPREREQUISITES");

            entity.Property(e => e.PrerequisiteId)
                .HasColumnType("NUMBER")
                .HasColumnName("PREREQUISITE_ID");
            entity.Property(e => e.CourseId)
                .HasColumnType("NUMBER")
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.PrerequisiteText)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PREREQUISITE_TEXT");

            entity.HasOne(d => d.Course).WithMany(p => p.Courseprerequisites)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("REQUIRES");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("SYS_C008285");

            entity.ToTable("ENROLLMENT");

            entity.HasIndex(e => new { e.StudentId, e.CourseId }, "UQ_ENROLLMENT_STUDENT_COURSE").IsUnique();

            entity.Property(e => e.EnrollmentId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ENROLLMENT_ID");
            entity.Property(e => e.CourseId)
                .HasColumnType("NUMBER")
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("ENROLLMENT_DATE");
            entity.Property(e => e.FeePaid)
                .HasColumnType("NUMBER")
                .HasColumnName("FEE_PAID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.StudentId)
                .HasColumnType("NUMBER")
                .HasColumnName("STUDENT_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("HAS_ENROLLMENT");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("MARKS");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("SYS_C008244");

            entity.ToTable("INSTRUCTOR");

            entity.HasIndex(e => e.Email, "SYS_C008245").IsUnique();

            entity.Property(e => e.InstructorId)
                .HasColumnType("NUMBER")
                .HasColumnName("INSTRUCTOR_ID");
            entity.Property(e => e.Bio)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("BIO");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("SYS_C008269");

            entity.ToTable("LESSON");

            entity.Property(e => e.LessonId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("LESSON_ID");
            entity.Property(e => e.CourseId)
                .HasColumnType("NUMBER")
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lessonorder)
                .HasPrecision(5)
                .HasColumnName("LESSONORDER");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_LESSON_COURSE");
        });

        modelBuilder.Entity<Lessonprogress>(entity =>
        {
            entity.HasKey(e => e.ProgressId).HasName("SYS_C008292");

            entity.ToTable("LESSONPROGRESS");

            entity.HasIndex(e => new { e.EnrollmentId, e.LessonId }, "UQ_PROGRESS_ENROLLMENT_LESSON").IsUnique();

            entity.Property(e => e.ProgressId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PROGRESS_ID");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("DATE")
                .HasColumnName("COMPLETED_AT");
            entity.Property(e => e.EnrollmentId)
                .HasColumnType("NUMBER")
                .HasColumnName("ENROLLMENT_ID");
            entity.Property(e => e.LessonId)
                .HasColumnType("NUMBER")
                .HasColumnName("LESSON_ID");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Lessonprogresses)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("TRACKS");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Lessonprogresses)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("COMPLETED_IN");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("SYS_C008282");

            entity.ToTable("MATERIALS");

            entity.Property(e => e.MaterialId)
                .HasColumnType("NUMBER")
                .HasColumnName("MATERIAL_ID");
            entity.Property(e => e.LessonId)
                .HasColumnType("NUMBER")
                .HasColumnName("LESSON_ID");
            entity.Property(e => e.MaterialUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("MATERIAL_URL");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Materials)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("HAS_MATERIAL");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("SYS_C008254");

            entity.ToTable("STUDENTS");

            entity.HasIndex(e => e.Email, "UQ_STUDENTS_EMAIL").IsUnique();

            entity.Property(e => e.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE");
        });
        modelBuilder.HasSequence("ADMIN_SEQ");
        modelBuilder.HasSequence("CATEGORIES_SEQ");
        modelBuilder.HasSequence("INSTRUCTOR_SEQ");
        modelBuilder.HasSequence("MATERIALS_SEQ");
        modelBuilder.HasSequence("OBJECTIVES_SEQ");
        modelBuilder.HasSequence("PREREQUISITES_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

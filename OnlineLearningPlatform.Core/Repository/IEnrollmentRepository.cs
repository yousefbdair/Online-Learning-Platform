using OnlineLearningPlatform.Core.Models;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface IEnrollmentRepository
    {
        List<Enrollment> GetAllEnrollments();
        void CreateEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int id);
        Enrollment GetEnrollmentById(int id);
        List<Enrollment> GetEnrollmentsByStudent(int studentId);
        List<Enrollment> GetEnrollmentsByCourse(int courseId);
    }
}
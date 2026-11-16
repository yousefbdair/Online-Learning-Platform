using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface IEnrollmentService
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

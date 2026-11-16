using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.Infra.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository _enrollmentRepository)
        {
            enrollmentRepository = _enrollmentRepository;
        }

        public List<Enrollment> GetAllEnrollments()
        {
            return enrollmentRepository.GetAllEnrollments();
        }

        public void CreateEnrollment(Enrollment enrollment)
        {
            enrollmentRepository.CreateEnrollment(enrollment);
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            enrollmentRepository.UpdateEnrollment(enrollment);
        }

        public void DeleteEnrollment(int id)
        {
            enrollmentRepository.DeleteEnrollment(id);
        }

        public Enrollment GetEnrollmentById(int id)
        {
            return enrollmentRepository.GetEnrollmentById(id);
        }

        public List<Enrollment> GetEnrollmentsByStudent(int studentId)
        {
            return enrollmentRepository.GetEnrollmentsByStudent(studentId);
        }

        public List<Enrollment> GetEnrollmentsByCourse(int courseId)
        {
            return enrollmentRepository.GetEnrollmentsByCourse(courseId);
        }
    }
}


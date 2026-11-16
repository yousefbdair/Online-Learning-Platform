using OnlineLearningPlatform.API.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Infra.Service
{
    public class CourseService : ICourseService 
    {
        private readonly ICourseRepository corseRepository;
        public CourseService(ICourseRepository _corseRepository)
        {
            corseRepository = _corseRepository;
        }
        public List<Course> GetAllCourses()
        {
            return corseRepository.GetAllCourses();
        }
        public void CreateCourse(Course course)
        {
            corseRepository.CreateCourse(course);
        }
        public void UpdateCourse(Course course)
        {
            corseRepository.UpdateCourse(course);
        }
        public void DeleteCourse(int id)
        {
            corseRepository.DeleteCourse(id);
        }
        public Course GetCourseById(int id)
        {
            return corseRepository.GetCourseById(id);
        }
    }
}

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
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository lessonRepository;
        public LessonService(ILessonRepository _lessonRepository)
        {
            lessonRepository = _lessonRepository;
        }
        public List<Lesson> GetAllLesson()
        {
            return lessonRepository.GetAllLesson();
        }
        public void CreateLesson(Lesson lesson)
        {
            lessonRepository.CreateLesson(lesson);
        }
        public void UpdateLesson(Lesson lesson)
        {
            lessonRepository.UpdateLesson(lesson);
        }
        public void DeleteLesson(int id)
        {
            lessonRepository.DeleteLesson(id);
        }
        public Lesson GetLessonById(int id)
        {
            return lessonRepository.GetLessonById(id);
        }
        public List<Lesson> GetLessonsByCourse(int courseId)
        {
            return lessonRepository.GetLessonsByCourse(courseId);
        }
    }
}


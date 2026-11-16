using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ILessonService
    {
        public List<Lesson> GetAllLesson();
        public void CreateLesson(Lesson lesson);
        public void UpdateLesson(Lesson lesson);
        public void DeleteLesson(int id);
        public Lesson GetLessonById(int id);
        public List<Lesson> GetLessonsByCourse(int courseId);
    }
}



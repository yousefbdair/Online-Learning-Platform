using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;

namespace OnlineLearningPlatform.Core.Service
{
    public interface ILessonProgressService
    {
        public List<Lessonprogress> GetAllProgress();
        public void CreateProgress(Lessonprogress progress);
        public void UpdateProgress(Lessonprogress progress);
        public void DeleteProgress(int id);
        public Lessonprogress GetProgressById(int id);
    }
}

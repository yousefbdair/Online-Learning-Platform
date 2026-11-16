using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Core.Models;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface ILessonProgressRepository
    {
        public List<Lessonprogress> GetAllProgress();
        public void CreateProgress(Lessonprogress progress);
        public void UpdateProgress(Lessonprogress progress);
        public void DeleteProgress(int id);
        public Lessonprogress GetProgressById(int id);
    }
}


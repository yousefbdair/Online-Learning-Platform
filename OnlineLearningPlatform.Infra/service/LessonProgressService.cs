using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Infra.Service
{
    public class LessonProgressService : ILessonProgressService
    {
        private readonly ILessonProgressRepository lessonProgressRepository;
        public LessonProgressService(ILessonProgressRepository _lessonProgressRepository)
        {
            lessonProgressRepository = _lessonProgressRepository;
        }
        public List<Lessonprogress> GetAllProgress()
        {
            return lessonProgressRepository.GetAllProgress();
        }
        public void CreateProgress(Lessonprogress progress)
        {
            lessonProgressRepository.CreateProgress(progress);
        }
        public void UpdateProgress(Lessonprogress progress)
        {
            lessonProgressRepository.UpdateProgress(progress);
        }
        public void DeleteProgress(int id)
        {
            lessonProgressRepository.DeleteProgress(id);
        }
        public Lessonprogress GetProgressById(int id)
        {
            return lessonProgressRepository.GetProgressById(id);
        }
    }
}


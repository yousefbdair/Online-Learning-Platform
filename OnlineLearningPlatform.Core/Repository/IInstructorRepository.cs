using OnlineLearningPlatform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Core.Repository
{
    public interface IInstructorRepository
    {
        public List<Instructor> GetAllInstructor();
        public Instructor GetInstructorById(int id);
        public void CreateInstructor(Instructor instructor);
        public void UpdateInstructor(Instructor instructor);
        public void DeleteInstructor(int id);
    }
}

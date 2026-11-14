using OnlineLearningPlatform.Core.Models;
using OnlineLearningPlatform.Core.Repository;
using OnlineLearningPlatform.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Infra.service
{
    public class InstructorService: IInstructorService
    {
        private IInstructorRepository instructorRepository;
        public InstructorService(IInstructorRepository _instructorRepository)
        {
            instructorRepository = _instructorRepository;
        }
        public List<Instructor> GetAllInstructor()
        {
            return instructorRepository.GetAllInstructor();
        }
        public Instructor GetInstructorById(int id)
        {
            return instructorRepository.GetInstructorById(id);
        }
        public void CreateInstructor(Instructor instructor)
        {
            instructorRepository.CreateInstructor(instructor);
        }
        public void UpdateInstructor(Instructor instructor)
        {
            instructorRepository.UpdateInstructor(instructor);
        }
        public void DeleteInstructor(int id)
        {
            instructorRepository.DeleteInstructor(id);
        }
    }
}

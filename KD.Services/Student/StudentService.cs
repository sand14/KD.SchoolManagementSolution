using KD.Common.Model.Automapper;
using KD.Common.Model.Models;
using KD.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Student
{
    public class StudentService : IStudentService
    {
        #region Fields
        
        private readonly SchoolContext _dbContext;

        #endregion
        public StudentService(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region Methods

        public IEnumerable<StudentModel> GetStudents()
        {
            var students = _dbContext.Students.Select(x => x.ToModel()).ToList();
            return students;
        }

        public StudentModel CreateStudent(StudentModel student)
        {
            

            if (student == null) return null;

            Core.DomainModels.Student studentEntity = student.ToEntity();
            _dbContext.Students.Add(studentEntity);
            _dbContext.SaveChanges();

            return GetStudentById(studentEntity.StudentId);
        }

        public StudentModel GetStudentById(Guid studentId)
        {
            try
            {
                var student = _dbContext.Students.First(s => s.StudentId == studentId);
                return student.ToModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateStudent(StudentModel student)
        {
            if (student == null) return;
            var studentEntity = _dbContext.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (studentEntity == null) return;

            _dbContext.Students.Update(student.ToEntity());
            _dbContext.SaveChanges();
        }

        public void RemoveStudent(Guid studentId)
        {
            var studententity = _dbContext.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (studententity == null) return;
            _dbContext.Students.Remove(studententity);
            _dbContext.SaveChanges();
        }

        #endregion
    }
}

using KD.Common.Model.Automapper;
using KD.Common.Model.Models;
using KD.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        #region fields
        private readonly SchoolContext _dbContext;
        #endregion


        #region constructor
        public TeacherService(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region methods
        public IEnumerable<TeacherModel> GetTeachers()
        {
            var teachers = _dbContext.Teachers.Select(x => x.ToModel()).AsEnumerable().OrderBy(d => d.DateOfBirth).ToList();
            return teachers;
        }

        public TeacherModel CreateTeacher(TeacherModel teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException();
            Core.DomainModels.Teacher teacherEntity = teacher.ToEntity();
            _dbContext.Teachers.Add(teacherEntity);
            _dbContext.SaveChanges();
            return teacherEntity.ToModel();
        }

        public TeacherModel GetTeacherById(Guid teacherId)
        {

            var teacher = _dbContext.Teachers.First(x=> x.TeacherId == teacherId);
            
            return teacher?.ToModel();
        }

        public void RemoveTeacher(Guid teacherId)
        {
            var teacherEntity = _dbContext.Teachers.FirstOrDefault(x => x.TeacherId == teacherId);
            if (teacherEntity == null) return;
            _dbContext.Teachers.Remove(teacherEntity);
            _dbContext.SaveChanges();
        }

        public void UpdateTeacher(TeacherModel teacher)
        {
            if(teacher == null) throw new ArgumentNullException();
            var teacherDb = _dbContext.Teachers.FirstOrDefault(x => x.TeacherId == teacher.TeacherId);
            if (teacherDb == null) return;
            teacherDb.CourseId = teacher.CourseId;
            teacherDb.FirstName = teacher.FirstName;
            teacherDb.LastName = teacher.LastName;
            //var teacherEntity = teacher.ToEntity();
            _dbContext.Teachers.Update(teacherDb);
            _dbContext.SaveChanges();
            
        }
        #endregion
    }
}

using KD.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Teacher
{
    public interface ITeacherService
    {
        IEnumerable<TeacherModel> GetTeachers();
        TeacherModel CreateTeacher(TeacherModel teacher);
        TeacherModel GetTeacherById(Guid teacherId);
        void RemoveTeacher(Guid teacherId);
        void UpdateTeacher(TeacherModel teacher);
    }
}

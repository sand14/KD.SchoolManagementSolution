using KD.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Student
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetStudents();
        StudentModel CreateStudent(StudentModel student);
        StudentModel GetStudentById(Guid studentId);
        void UpdateStudent(StudentModel student);
        void RemoveStudent(Guid studentId);

    }
}

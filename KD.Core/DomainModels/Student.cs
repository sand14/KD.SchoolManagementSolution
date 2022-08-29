using System;
using System.Collections.Generic;

namespace KD.Core.DomainModels
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            Courses = new HashSet<Course>();
        }

        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int IdentificationNumber { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}

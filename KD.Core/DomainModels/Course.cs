using System;
using System.Collections.Generic;

namespace KD.Core.DomainModels
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
            Teachers = new HashSet<Teacher>();
            Students = new HashSet<Student>();
        }

        public Guid CourseId { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int? SpecializationId { get; set; }
        public bool? Optional { get; set; }

        public virtual Specialization? Specialization { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace KD.Core.DomainModels
{
    public partial class Specialization
    {
        public Specialization()
        {
            Courses = new HashSet<Course>();
            Teachers = new HashSet<Teacher>();
        }

        public int SpecializationId { get; set; }
        public string Name { get; set; } = null!;
        public int? Rating { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}

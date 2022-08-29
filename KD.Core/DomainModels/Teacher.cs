using System;
using System.Collections.Generic;

namespace KD.Core.DomainModels
{
    public partial class Teacher
    {
        public Guid TeacherId { get; set; }
        public Guid? CourseId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? SpecializationId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Specialization? Specialization { get; set; }
    }
}

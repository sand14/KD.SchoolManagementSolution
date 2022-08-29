using System;
using System.Collections.Generic;

namespace KD.Core.DomainModels
{
    public partial class Grade
    {
        public Guid GradeId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public double GradeValue { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public string? Observations { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}

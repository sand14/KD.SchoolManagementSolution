
namespace KD.Common.Model.Models
{
    public class GradeModel
    {
        public Guid GradeId { get; set; }
        public double GradeValue { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public string? Observations { get; set; }

    }
}

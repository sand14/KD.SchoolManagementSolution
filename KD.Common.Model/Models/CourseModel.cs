
namespace KD.Common.Model.Models
{
    public class CourseModel
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int? SpecializationId { get; set; }
        public bool? Optional { get; set; }

        public SpecializationModel? Specialization { get; set; }

    }
}

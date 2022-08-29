
namespace KD.Common.Model.Models
{
    public class TeacherModel
    {

        public Guid TeacherId { get; set; }
        public Guid? CourseId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? SpecializationId { get; set; }

        public virtual CourseModel? Course { get; set; }
        public virtual SpecializationModel? Specialization { get; set; }
    }
}

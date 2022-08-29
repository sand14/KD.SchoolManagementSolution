namespace KD.Common.Model.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
            Courses = new HashSet<CourseModel>();
            Grades = new HashSet<GradeModel>();
        }

        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int IdentificationNumber { get; set; }

        public ICollection<CourseModel> Courses { get; set; }
        public virtual ICollection<GradeModel> Grades { get; set; }
    }
}

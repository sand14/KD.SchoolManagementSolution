using KD.Common.Model.Automapper;
using KD.Common.Model.Models;
using KD.Core.DomainModels;
using KD.Services.Student;
using Microsoft.EntityFrameworkCore;

namespace KD.Test.Services
{
    public class Tests
    {
        private SchoolContext _dbContext;
        [OneTimeSetUp]
        public void Setup()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var options = new DbContextOptionsBuilder<SchoolContext>();
            options.UseNpgsql("Host=localhost;Database=pharmacy;Username=postgres;Password=post;Persist Security Info=True");
            _dbContext = new SchoolContext(options.Options);

            AutoMapperConfiguration.Init();
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();

        }

        [OneTimeTearDown]
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        [Test]
        public void GetStudentsTest()
        {
            var service = new StudentService(_dbContext);

            var student = CreateStudentModel("firstname", "lastname", DateTime.Now, false);
            var createdStudent = service.CreateStudent(student);

            var students = service.GetStudents();

            Assert.That(students, Has.Exactly(1).Items);

            service.RemoveStudent(createdStudent.StudentId);
        }

        [Test]
        public void CreateStudentTest()
        {
            //arrange
                var service = new StudentService(_dbContext);
                var student = CreateStudentModel("firstname", "lastname", DateTime.Now, false);
                var createdStudent = service.CreateStudent(student);
                //assert
                Assert.That(createdStudent != null);
                Assert.That(createdStudent?.FirstName == student.FirstName);
                Assert.That(createdStudent?.LastName == student.LastName);

                service.RemoveStudent(createdStudent.StudentId);
        }

        public StudentModel CreateStudentModel(string firstName, string lastName, DateTime dateTime, bool includedCourse = true)
        {
            var student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateTime,
                Courses = new List<Course>()
                {

                }
            };
            if (includedCourse)
            {
                Course course = _dbContext.Courses.First(x => x.CourseId == new Guid("51AD2E2F-4414-4F89-A0E5-01F5CA0598C4"));
                student.Courses.Add(course);
            }

            return student.ToModel();
        }

        [Test]
        public void RemoveStudentTest()
        {
            //arrange
            var service = new StudentService(_dbContext);
            StudentModel student = CreateStudentModel("George", "Georgescu", DateTime.Today.AddYears(-30),false);
            StudentModel createdStudent = service.CreateStudent(student);

            //act
            service.RemoveStudent(createdStudent.StudentId);

            //assert
            var deletedStudent = _dbContext.Students.FirstOrDefault(c => c.StudentId == createdStudent.StudentId);
            Assert.That(deletedStudent == null);
        }

    }
}
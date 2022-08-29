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
            var options = new DbContextOptionsBuilder<SchoolContext>();
            options.UseSqlServer("Server=DESKTOP-F92FLLN\\SQLEXPRESS;Database=School;Trusted_Connection=True");
            _dbContext = new SchoolContext(options.Options);

            AutoMapperConfiguration.Init();
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();

        }

        [Test]
        public void GetStudentsTest()
        {
            var service = new StudentService(_dbContext);

            var students = service.GetStudents();

            Assert.That(students.Any());
        }

        [Test]
        public void CreateStudentTest()
        {
            StudentService service;
            Guid createStudentId;
            try
            {
                //arrange
                service = new StudentService(_dbContext);

                //assert
                Assert.That(createdStudent != null);
                Assert.That(createdStudent?.FirstName == student.FirstName);
                Assert.That(createdStudent?.LastName == student.LastName);
                //Assert.That(createdStudent?.Courses.Any() ?? false); 
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                service.RemoveStudent(createdStudent.StudentId);
            }
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
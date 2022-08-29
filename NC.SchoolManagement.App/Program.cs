// See https://aka.ms/new-console-template for more information
using KD.Core.DomainModels;
using KD.Services.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NC.SchoolManagement.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceProvider serviceProvider = null;
            ServiceProvider serviceProvider = SetUpServices();

            //GetStudentsList(serviceProvider);
            //CreateStudent(serviceProvider);
            //GetStudentsList(serviceProvider);
        }


        private static ServiceProvider SetUpServices()
        {
            string connectionString = "Server=DESKTOP-7AHO1V2\\SQLEXPRESS;Database=School;Trusted_Connection=True;";
            var services = new ServiceCollection();
            services.AddSingleton<IStudentService, StudentService>();
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connectionString));
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        private static IStudentService GetStudentService(ServiceProvider serviceProvider)
        {
            if (serviceProvider == null) throw new Exception("Service provider not initialized!");

            return serviceProvider.GetService<IStudentService>() ?? throw new Exception("Service not registered!");

        }


        #region Students methods

        private static void GetStudentsList(ServiceProvider serviceProvider)
        {
            try
            {
                var studentService = GetStudentService(serviceProvider);
                var students = studentService.GetStudents();

                if (students.Any())
                {
                    foreach (var student in students)
                        Console.WriteLine($"{student.StudentId}, {student.FirstName} {student.LastName}");
                }
                else
                {
                    Console.WriteLine("No students found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        //private static void CreateStudent(ServiceProvider serviceProvider)
        //{
        //    var studentService = GetStudentService(serviceProvider);

        //    var student = new Student()
        //    {
        //        FirstName = "Mihai",
        //        LastName = "Ionel",
        //        DateOfBirth = new DateTime(1997, 12, 12)
        //    };

        //    studentService.CreateStudent(student);
        //}


        //private static void UpdateStudent(ServiceProvider serviceProvider)
        //{
        //    var studentService = GetStudentService(serviceProvider);
        //    var student = studentService.GetStudent(new Guid("120B3877-D734-4FCD-ABDA-782CD11760B7"));
        //    if (student != null)
        //    {
        //        student.FirstName = "Test1";
        //        studentService.UpdateStudent(student);
        //    }
        //    GetStudentsList(serviceProvider);
        //}

        //private static void UpdateStudent2(ServiceProvider serviceProvider)
        //{
        //    var studentService = GetStudentService(serviceProvider);
        //    var student = studentService.GetStudent(new Guid("120B3877-D734-4FCD-ABDA-782CD11760B7"));
        //    if (student != null)
        //    {
        //        student.FirstName = "Test2";
        //        studentService.UpdateStudent2(student);
        //    }
        //    GetStudentsList(serviceProvider);
        //}
        #endregion
    }

}
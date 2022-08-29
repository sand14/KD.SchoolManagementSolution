using KD.Services.Student;
using KD.Services.Teacher;

namespace NC.Web.API
{
    public class DependencyRegistration
    {
        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="builder"></param>
        public void Register(IServiceCollection builder)
        {
            //Per request lifetime

            //Singleton services

            //Transient services

            //builder.AddTransient(typeof(IRepository<>), typeof(EFCoreRepository<>));
            builder.AddTransient<IStudentService, StudentService>();
            builder.AddTransient<ICourseService, CourseService>();
            builder.AddTransient<ITeacherService, TeacherService>();
        }

    }
}

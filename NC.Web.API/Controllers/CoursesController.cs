using KD.Common.Model.Models;
using KD.Services.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NC.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [Route("/api/Courses")]
        [HttpGet]
        public IEnumerable<CourseModel> Get()
        {
            try
            {
                var courses = courseService.GetCourses();

                return courses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

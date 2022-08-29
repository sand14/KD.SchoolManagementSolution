using KD.Common.Model.Models;
using KD.Services.Student;
using KD.Services.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NC.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [Route("/api/Teachers")]
        [HttpGet]
        public IEnumerable<TeacherModel> Get()
        {
            try
            {
                var teachers = teacherService.GetTeachers();

                return teachers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [Route("/api/Teachers")]
        [HttpPost]
        public TeacherModel Create([FromBody] TeacherModel teacher)
        {
            try
            {
                teacher = teacherService.CreateTeacher(teacher);

                return teacher;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [Route("/api/Teachers/{teacherId}")]
        [HttpGet]
        public TeacherModel GetTeacherById([FromRoute] Guid teacherId)
        {
            try
            {
                return teacherService.GetTeacherById(teacherId);
            }
            catch (InvalidOperationException)
            {

                throw new Exception("Not Found");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
         
        }

        [Route("/api/Teachers")]
        [HttpPut]
        public bool UpdateTeacher([FromBody] TeacherModel teacher)
        {
            try
            {
                teacherService.UpdateTeacher(teacher);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/api/Teachers/{teacherId}")]
        [HttpDelete]
        public void DeleteTeacherById([FromRoute] Guid teacherId)
        {
            try
            {
                teacherService.RemoveTeacher(teacherId);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
    }
}

using KD.Common.Model.Automapper;
using KD.Common.Model.Models;
using KD.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Student
{
    public class CourseService : ICourseService
    {
        #region fields
        private readonly SchoolContext _dbContext;
        #endregion


        #region constructor
        public CourseService(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region methods
        public IEnumerable<CourseModel> GetCourses()
        {
            var courses = _dbContext.Courses.Select(x => x.ToModel()).AsEnumerable().OrderBy(d => d.Name).ToList();
            return courses;
        }
        #endregion
    }
}

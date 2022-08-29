﻿using KD.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Student
{
    public interface ICourseService
    {
        IEnumerable<CourseModel> GetCourses();
    }
}

using AutoMapper;
using KD.Common.Model.Models;
using KD.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Common.Model.Automapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Student, StudentModel>()
               //.ForMember(s => s.Courses, d => d.Ignore())
              .ForMember(s => s.Grades, d => d.Ignore());
            //.ForMember(s => s.FullName, d => d.MapFrom(new FullNameResolver()));
            CreateMap<StudentModel, Student>()
                //.ForMember(s => s.Courses, d => d.Ignore())
                .ForMember(s => s.Grades, d => d.Ignore());

            CreateMap<Grade, GradeModel>();
            CreateMap<GradeModel, Grade>()
                .ForMember(s => s.Student, d => d.Ignore())
                .ForMember(s => s.Course, d => d.Ignore())
                .ForMember(s => s.StudentId, d => d.Ignore())
                .ForMember(s => s.CourseId, d => d.Ignore());

            CreateMap<Teacher, TeacherModel>()
                .ForMember(s => s.Course, d => d.Ignore());
            CreateMap<TeacherModel, Teacher>()
                .ForMember(s => s.Course, d => d.Ignore());


            CreateMap<Course, CourseModel>();
            CreateMap<CourseModel, Course>()
                .ForMember(s => s.Teachers, d => d.Ignore())
                .ForMember(s => s.Grades, d => d.Ignore())
                .ForMember(s => s.Students, d => d.Ignore());

            CreateMap<Specialization, SpecializationModel>();
            CreateMap<SpecializationModel, Specialization>()
                .ForMember(s => s.Courses, d => d.Ignore())
                .ForMember(s => s.Teachers, d => d.Ignore());
        }

    }
}

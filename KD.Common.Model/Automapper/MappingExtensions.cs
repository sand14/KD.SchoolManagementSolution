using AutoMapper;
using KD.Common.Model.Models;
using KD.Core.DomainModels;

namespace KD.Common.Model.Automapper
{
    public static class MappingExtensions
    {
        private static readonly IMapper mapper = AutoMapperConfiguration.Mapper;

        public static StudentModel ToModel(this Student entity)
        {
            return mapper.Map<StudentModel>(entity);
        }

        public static Student ToEntity(this StudentModel model)
        {
            return mapper.Map<Student>(model);
        }

        public static CourseModel ToModel(this Course entity)
        {
            return mapper.Map<CourseModel>(entity);
        }
        public static Course ToEntity(this CourseModel model)
        {
            return mapper.Map<Course>(model);
        }
        public static TeacherModel ToModel(this Teacher entity)
        {
            return mapper.Map<TeacherModel>(entity);
        }
        public static Teacher ToEntity(this TeacherModel model)
        {
            return mapper.Map<Teacher>(model);
        }


    }
}

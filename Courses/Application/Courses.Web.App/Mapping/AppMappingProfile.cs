using AutoMapper;


namespace Courses.Web.App
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Course, CourseModel>();

            CreateMap<Group, GroupModel>();

            CreateMap<Student, StudentModel>().ReverseMap();
        }
    }
}
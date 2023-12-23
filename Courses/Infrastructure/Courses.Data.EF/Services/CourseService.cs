using AutoMapper;
using Courses.Web.App;
using Microsoft.EntityFrameworkCore;


namespace Courses.Data.EF
{
    public class CourseService
    {
        private readonly CoursesContext db;
        private readonly IMapper mapper;

        public CourseService(CoursesContext coursesContext, IMapper mapper)
        {
            db = coursesContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CourseModel>> GetAllCoursesAsync()
        {
            var model = await db.Courses.ToListAsync();

            return Map(model);
        }

        private List<CourseModel> Map(List<Course> courses)
        {
            var courseModel = mapper.Map<List<CourseModel>>(courses);

            return courseModel;
        }
    }
}
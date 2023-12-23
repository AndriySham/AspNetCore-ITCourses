using Microsoft.EntityFrameworkCore;
using Courses.Data.EF;
using Courses.Web.App;


namespace PatternForMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CoursesContext>(options => options.UseSqlServer(connection));
            services.AddScoped<CourseService>();
            services.AddScoped<GroupService>();
            services.AddScoped<StudentService>();
            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
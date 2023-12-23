using Courses.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Courses.Data.EF;


namespace Courses.Controllers
{
    public class HomeController : Controller
    {
        CourseService courseService;

        public HomeController(CourseService courseService)
        {
            this.courseService = courseService;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            var courseModel = await courseService.GetAllCoursesAsync();

            return View(courseModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
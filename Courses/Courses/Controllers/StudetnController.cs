using Courses.Data.EF;
using Courses.Web.App;
using Microsoft.AspNetCore.Mvc;


namespace Courses.Controllers
{
    public class StudentController : Controller
    {
        StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [Route("Student/DeleteStudent/{id?}")]
        [HttpGet]
        [ActionName("DeleteStudent")]
        public async Task<IActionResult> ConfirmDeleteStudentAsync(int? id)
        {
            if (id != null)
            {
                StudentModel studentModel =await  studentService.ConfirmDeleteStudentOrReturnNullAsync(id);
                if (studentModel != null)
                    return View("DeleteStudent", studentModel);
            }
            return NotFound();
        }

        [Route("Student/DeleteStudent/{id?}")]
        [HttpPost]
        public async Task<IActionResult> DeleteStudentAsync(int? id)
        {
            if (id != null)
            {
                int groupId = await studentService.TryDeleteStudentAsync(id);

                if (groupId != 0)
                    return RedirectPermanent($"~/Student/DisplayStudent/{id = groupId}");
            }
            return NotFound();
        }

        [Route("Student/DisplayStudent/{id?}")]
        public async Task<IActionResult> DisplayStudent(int? id)
        {
            if (id == null) return RedirectPermanent("~/Home/Index");

            ViewBag.GroupId = id;
            var studentModel = await studentService.GetAllStudentsAsync();

            return View("DisplayStudent", studentModel);
        }

        [Route("Student/EditStudent/{id?}")]
        [HttpGet]
        public async Task<IActionResult> EditStudentAsync(int? id)
        {
            if (id != null)
            {
                var student = await studentService.GetStudentAsync(id);
                if (student != null) return View("EditStudent", student);
            }
            return NotFound();
        }

        [Route("Student/EditStudent/{id?}")]
        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentModel studentModel)
        {
            int id;
            int groupId = studentModel.GroupId;
            await studentService.UpdateStudentAsync(studentModel);

            return RedirectPermanent($"~/Student/DisplayStudent/{id = groupId}");
        }
    }
}
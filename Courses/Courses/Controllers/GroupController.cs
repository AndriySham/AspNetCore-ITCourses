using Courses.Data.EF;
using Microsoft.AspNetCore.Mvc;


namespace Courses.Controllers
{
    public class GroupController : Controller
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [Route("Group/DeleteGroup/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var deletedResult = await _groupService.DeleteGroupAsync(id);
                if (deletedResult)
                {
                    return RedirectPermanent($"~/Group/DisplayGroup/{id = id}");
                }
                else
                {
                    return RedirectPermanent("~/Group/ForbidToDeleteGroup");
                }
            }
            return NotFound();
        }

        [Route("Group/DisplayGroup/{id?}")]
        public async Task<IActionResult> DisplayGroupAsync(int? id)
        {
            if (id == null) return RedirectPermanent("~/Home/Index");

            ViewBag.CourseId = id;
            var groupModel = await _groupService.GetAllGroupsAsync();

            return View(groupModel);
        }

        [Route("Group/ForbidToDeleteGroup")]
        public async Task<IActionResult> ForbidToDeleteGroupAsync()
        {
            return View("ForbidToDeleteGroup");
        }
    }
}
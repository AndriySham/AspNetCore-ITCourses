using AutoMapper;
using Courses.Web.App;
using Microsoft.EntityFrameworkCore;


namespace Courses.Data.EF
{
    public class GroupService
    {
        private readonly CoursesContext db;
        private readonly IMapper mapper;

        public GroupService(CoursesContext coursesContext, IMapper mapper)
        {
            db = coursesContext;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteGroupAsync(int? groupId)
        {
            bool deletedResult = false;

            if (groupId is null)
                return deletedResult;

            Group? group =  await db.Groups.FirstOrDefaultAsync(g => g.Id == groupId);
            if (group is null)
                return deletedResult;

            int countStudent =  await db.Students.CountAsync(g => g.GroupId == groupId);

            if (countStudent == 0)
            {
                db.Groups.Remove(group);
                await db.SaveChangesAsync();
                deletedResult = true;
            }

            return deletedResult;
        }

        public async Task<List<GroupModel>> GetAllGroupsAsync()
        {
            var model = await db.Groups.ToListAsync();

            return Map(model);
        }

        private List<GroupModel> Map(List<Group> groups)
        {
            var groupModel = mapper.Map<List<GroupModel>>(groups);

            return groupModel;
        }
    }
}
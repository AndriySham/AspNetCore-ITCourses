using AutoMapper;
using Courses.Web.App;
using Microsoft.EntityFrameworkCore;


namespace Courses.Data.EF
{
    public class StudentService
    {
        private readonly CoursesContext db;
        private readonly IMapper mapper;

        public StudentService(CoursesContext coursesContext, IMapper mapper)
        {
            db = coursesContext;
            this.mapper = mapper;
        }

        public async Task<StudentModel> ConfirmDeleteStudentOrReturnNullAsync(int? id)
        {
            if (id != null)
            {
                Student student = await db.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student != null)
                    return Map(student);
            }
            return null;
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudentsAsync()
        {
            var model = await db.Students.ToListAsync();

            return Map(model);
        }

        public async Task<StudentModel> GetStudentAsync(int? studentIid)
        {
            var student = await db.Students.FirstOrDefaultAsync(s => s.Id == studentIid);

            return Map(student);
        }

        public async Task<int> TryDeleteStudentAsync(int? studentId)
        {
            int groupId = 0;

            Student student = await db.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            if (student != null)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();

                groupId = student.GroupId;
            }
            return groupId;
        }

        public async Task UpdateStudentAsync(StudentModel studentModel)
        {
            var student = Map(studentModel);
            db.Students.Update(student);
            await db.SaveChangesAsync();
        }

        private Student Map(StudentModel studentModel)
        {
            var student = mapper.Map<Student>(studentModel);

            return student;
        }

        private StudentModel Map(Student student)
        {
            var studentModel = mapper.Map<StudentModel>(student);

            return studentModel;
        }

        private List<StudentModel> Map(List<Student> student)
        {
            var studentModel = mapper.Map<List<StudentModel>>(student);

            return studentModel;
        }
    }
}
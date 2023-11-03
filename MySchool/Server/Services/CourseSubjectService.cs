using MySchool.Server.Data;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Services
{
    public class CourseSubjectService : GenericService<CourseSubject>, ICourseSubjectService
    {
        public CourseSubjectService(AppDbContext context) : base(context)
        {
        }
    }
}

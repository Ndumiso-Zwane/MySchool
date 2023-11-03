using MySchool.Server.Data;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Services
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(AppDbContext context) : base(context)
        {
        }
    }
}

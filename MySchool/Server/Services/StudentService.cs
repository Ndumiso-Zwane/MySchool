using MySchool.Server.Data;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Services
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(AppDbContext context) : base(context)
        {
        }
    }
}

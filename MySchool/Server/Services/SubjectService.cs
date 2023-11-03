using MySchool.Server.Data;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Services
{
    public class SubjectService : GenericService<Subject>, ISubjectService
    {
        public SubjectService(AppDbContext context) : base(context)
        {
        }
    }
}

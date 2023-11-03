using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Server.Data;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectController : ControllerBase
    {
        private readonly ICourseSubjectService _courseSubjectService;
        private readonly AppDbContext _context;

        public CourseSubjectController(ICourseSubjectService courseSubjectService, AppDbContext context)
        {
            _courseSubjectService = courseSubjectService;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Course>> GetCourseSubjects()
        {
            var courseSubjects = _context.CourseSubjects.Include(x => x.Course).Include(x => x.Subject).ToList();

            if (courseSubjects.Count < 0)
            {
                return NotFound("There are no courses.");
            }

            return Ok(courseSubjects);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Course>> GetCourseSubjectsByCourse(int id)
        {
            var courseSubjects = _context.CourseSubjects.Where(x => x.CourseId == id).Include(x => x.Course).Include(x => x.Subject).ToList();

            if (courseSubjects.Count < 0)
            {
                return NotFound("There are no courses.");
            }

            return Ok(courseSubjects);
        }

        [HttpPost]
        public ActionResult<Course> CreateCourseSubject(CourseSubject courseSubject)
        {
            courseSubject.Course = null;
            courseSubject.Subject = null;
            _courseSubjectService.Add(courseSubject);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var courseSubject = _courseSubjectService.GetById(id);

            if (courseSubject == null)
            {
                return NotFound("Course not found.");
            }

            _courseSubjectService.Delete(courseSubject);

            return Ok();
        }
    }
}

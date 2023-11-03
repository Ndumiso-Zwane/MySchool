using Microsoft.AspNetCore.Mvc;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<Course>> GetCourses()
        {
            var courses = _courseService.GetAll();

            if (courses.Count < 0)
            {
                return NotFound("There are no courses.");
            }

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = _courseService.GetById(id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> CreateCourse(Course course)
        {
            _courseService.Add(course);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCourse(Course course)
        {
            if(course == null)
            {
                return NotFound("Course not found.");
            }

            _courseService.Update(course);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var course = _courseService.GetById(id);
            
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            _courseService.Delete(course);

            return Ok();
        }
    }
}

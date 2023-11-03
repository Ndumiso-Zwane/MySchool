using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Server.Data;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly AppDbContext _context;

        public StudentsController(IStudentService studentService, AppDbContext context)
        {
            _studentService = studentService;
            _context = context;
        }

        [HttpGet]  
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _context.Students.Include(x => x.Course).ToListAsync();

            if(students.Count < 0)
            {
                return NotFound("There are no students.");
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Getstudent(int id)
        {
            var student = _studentService.GetById(id);

            if(student  == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            student.Course = null;

            _studentService.Add(student);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateStudent(Student student)
        {
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            _studentService.Update(student);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetById(id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            _studentService.Delete(student);

            return Ok();
        }
    }
}

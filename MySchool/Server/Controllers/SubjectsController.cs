using Microsoft.AspNetCore.Mvc;
using MySchool.Server.Interfaces;
using MySchool.Shared.Models;

namespace MySchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public ActionResult<List<Subject>> GetSubjects()
        {
            var subjects = _subjectService.GetAll();

            if (subjects.Count < 0)
            {
                return NotFound("There are no subjects.");
            }

            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public ActionResult<Subject> GetSubject(int id)
        {
            var subject = _subjectService.GetById(id);

            if (subject == null)
            {
                return NotFound("Subject not found.");
            }

            return Ok(subject);
        }

        [HttpPost]
        public ActionResult<Subject> CreateSubject(Subject subject)
        {
            _subjectService.Add(subject);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateSubject(Subject subject)
        {
            if (subject == null)
            {
                return NotFound("Subject not found.");
            }

            _subjectService.Update(subject);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSubject(int id)
        {
            var subject = _subjectService.GetById(id);

            if (subject == null)
            {
                return NotFound("Subject not found.");
            }

            _subjectService.Delete(subject);

            return Ok();
        }
    }
}

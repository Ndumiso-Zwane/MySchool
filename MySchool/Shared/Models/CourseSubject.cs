using System.ComponentModel.DataAnnotations;

namespace MySchool.Shared.Models
{
    public class CourseSubject
    {
        [Key]
        public int Id { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set; }
        public Subject? Subject { get; set; }
        public int SubjectId { get; set; }
    }
}

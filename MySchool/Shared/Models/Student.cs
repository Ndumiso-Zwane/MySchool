using System.ComponentModel.DataAnnotations;

namespace MySchool.Shared.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string EnrollmentStatus { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;

namespace MySchool.Shared.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

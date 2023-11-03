using System.ComponentModel.DataAnnotations;

namespace MySchool.Shared.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
    }
}

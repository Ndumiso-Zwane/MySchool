using MySchool.Shared.Models;

namespace MySchool.Client.Interfaces
{
    public interface IApiService
    {
        List<Student> Students { get; set; }
        List<Course> Courses { get; set; }
        List<Subject> Subjects { get; set; }
        List<CourseSubject> CourseSubjects { get; set; }

        Task GetStudents();
        Task<Student> GetStudent(int Id);
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int Id);
        Task GetCourses();
        Task<Course> GetCourse(int Id);
        Task CreateCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(int Id);
        Task GetSubjects();
        Task<Subject> GetSubject(int Id);
        Task CreateSubject(Subject subject);
        Task UpdateSubject(Subject subject);
        Task DeleteSubject(int Id);
        Task GetCourseSubjects();
        Task GetCourseSubjectsByCourse(int Id);
        Task CreateCourseSubject(CourseSubject courseSubject);
        Task DeleteCourseSubject(int Id);
    }
}

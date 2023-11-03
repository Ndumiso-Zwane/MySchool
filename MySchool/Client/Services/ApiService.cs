using Microsoft.AspNetCore.Components;
using MySchool.Client.Interfaces;
using MySchool.Shared.Models;
using System.Net.Http.Json;

namespace MySchool.Client.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ApiService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();

        public async Task CreateCourse(Course course)
        {
            var result = await _httpClient.PostAsJsonAsync("api/courses", course);

            if(result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/courses");
            }
        }

        public async Task CreateStudent(Student student)
        {
            var result = await _httpClient.PostAsJsonAsync("api/students", student);

            if(result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/students");
            }
        }

        public async Task CreateSubject(Subject subject)
        {
            var result = await _httpClient.PostAsJsonAsync("api/subjects", subject);

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/subjects");
            }
        }

        public async Task CreateCourseSubject(CourseSubject courseSubject)
        {
            var result = await _httpClient.PostAsJsonAsync("api/coursesubject", courseSubject);

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/coursesubjects");
            }
        }

        public async Task DeleteCourse(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/courses/{Id}");

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/courses", forceLoad: true);
            }
        }

        public async Task DeleteStudent(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/students/{Id}");

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/students", forceLoad: true);
            }
        }

        public async Task DeleteSubject(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/subjects/{Id}");

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/subjects", forceLoad: true);
            }
        }
        
        public async Task DeleteCourseSubject(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/courseSubject/{Id}");

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/coursesubjects", forceLoad: true);
            }
        }

        public async Task<Course> GetCourse(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Course>($"api/courses/{Id}");

            return result ?? throw new Exception("Course not found");
        }

        public async Task GetCourses()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Course>>("api/courses") ?? throw new Exception("No courses found.");

            Courses = result;
        }

        public async Task<Student> GetStudent(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Student>($"api/students/{Id}");

            return result ?? throw new Exception("Student not found");
        }

        public async Task GetStudents()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Student>>("api/students") ?? throw new Exception("No students found");
            
            Students = result;
        }

        public async Task<Subject> GetSubject(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Subject>($"api/subjects/{Id}");

            return result ?? throw new Exception("Subject not found");
        }

        public async Task GetSubjects()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Subject>>("api/subjects") ?? throw new Exception("No subjects found");

            Subjects = result;
        }

        public async Task GetCourseSubjects()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CourseSubject>>("api/coursesubject") ?? throw new Exception("No subjects found for this course.");

            CourseSubjects = result;
        }
        
        public async Task GetCourseSubjectsByCourse(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<CourseSubject>>($"api/coursesubject/{Id}") ?? throw new Exception("No subjects found for this course.");

            CourseSubjects = result;
        }

        public async Task UpdateCourse(Course course)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/courses", course);

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/courses");
            }
        }

        public async Task UpdateStudent(Student student)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/students", student);

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/students");
            }
        }

        public async Task UpdateSubject(Subject subject)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/subjects", subject);

            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/subjects");
            }
        }
    }
}

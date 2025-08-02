using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using StudentManagement.Shared;
using static System.Net.WebRequestMethods;

namespace StudentManagement.Client.Service
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public StudentService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            // 🔐 Add Authorization header before API call
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<IEnumerable<Student>>("api/Student/GetAllStudents");
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Student/AddStudent", student);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<Student>();
            }
            return null;
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _httpClient.GetFromJsonAsync<Student>($"api/Student/GetStudentById/{studentId}");
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var result = await _httpClient.DeleteAsync($"api/Student/DeleteStudent/{studentId}");
            return result.IsSuccessStatusCode;
        }

        public async Task<Student> UpdateStudent(int studentId,Student student)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Student/UpdateStudent/{studentId}", student);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<Student>();
            }
            return null;
        }

    }
}

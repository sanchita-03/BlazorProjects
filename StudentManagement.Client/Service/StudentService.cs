using System.Net.Http.Json;
using StudentManagement.Shared;
using static System.Net.WebRequestMethods;

namespace StudentManagement.Client.Service
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
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

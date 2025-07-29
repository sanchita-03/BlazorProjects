using StudentManagement.Shared;

namespace StudentManagement.Contract
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddStudentAyns(Student student);
        Task<Student> UpdateStudentAynsAsync(int studentId,Student student);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}

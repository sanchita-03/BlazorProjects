using Microsoft.EntityFrameworkCore;
using StudentManagement.Contract;
using StudentManagement.Data;
using StudentManagement.Shared;

namespace StudentManagement.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async Task<Student> AddStudentAyns(Student student)
        {
            //await _studentDbContext.Students.AddAsync(student);
            //await _studentDbContext.SaveChangesAsync();
            //return student;
            var result = await _studentDbContext.Students
                                          .FromSqlInterpolated($"EXEC AddStudent {student.FirstName},{student.LastName},{student.RollNo},{student.Address}")
                                          .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var result = await GetByIdAsync(studentId);
            if (result == null)
                return false;


            _studentDbContext.Students.Remove(result);
            return await _studentDbContext.SaveChangesAsync()>0;

        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentDbContext.Students
                .FromSqlRaw("EXEC GetAllStudents")
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentDbContext.Students.FindAsync(id);
        }

        public async Task<Student> UpdateStudentAynsAsync(int studentId, Student student)
        {
            var result = await GetByIdAsync(studentId);
            if (result == null)
                return null;
            result.FirstName = student.FirstName;
            result.LastName = student.LastName;
            result.RollNo = student.RollNo;
            result.Address = student.Address;
            _studentDbContext.Students.Update(result);
            await _studentDbContext.SaveChangesAsync();
            return student;
        }
    }
}

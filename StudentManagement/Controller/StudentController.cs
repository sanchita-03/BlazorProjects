using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Contract;
using StudentManagement.Shared;

namespace StudentManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentRepository.GetAllStudentsAsync();
            return Ok(result);
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody]Student student)
        {
            var result = await _studentRepository.AddStudentAyns(student);
            return Ok(result);
        }

        [HttpGet("GetStudentById/{studentId}")]
        public async Task<IActionResult> GetStudentById([FromRoute]int studentId)
        {
            var result = await _studentRepository.GetByIdAsync(studentId);
            return Ok(result);
        }

        [HttpPut("UpdateStudent/{studentId}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int studentId,[FromBody]Student student)
        {
            var result = await _studentRepository.UpdateStudentAynsAsync(studentId,student);
            return Ok(result);
        }

        [HttpDelete("DeleteStudent/{studentId}")]
        public async Task<IActionResult> DeleteStudent([FromRoute]int studentId)
        {
            var result = await _studentRepository.DeleteStudentAsync(studentId);
            return Ok(result);
        }
    }
}

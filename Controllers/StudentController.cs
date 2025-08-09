using Exam_Api_v2.DTOs;
using Exam_Api_v2.Repo.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Api_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentRepo;
        public StudentController(IStudent studentRepo)
        {
            _studentRepo = studentRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepo.GetAllStudents();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        {
            var student = await _studentRepo.CreateStudent(dto);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentUpdateDto dto)
        {
            var updatedStudent = await _studentRepo.UpdateStudent(id, dto);
            if (updatedStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(updatedStudent);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentRepo.DeleteStudent(id);
            if (!result)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return NoContent();
        }
    }
}

using Exam_Api_v2.Converter;
using Exam_Api_v2.Data;
using Exam_Api_v2.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student_ExamQBController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public Student_ExamQBController(AppDB_Context context)
        {
            _Context = context;
        }
 

        // GET: api/StudentExamQB/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentExamQBReadDTO>> GetStudentExamQB(int id)
        {
            var studentExamQB = await _Context.student_ExamQBs
                .Include(se => se.Student) // Load student data
                .FirstOrDefaultAsync(se => se.Student_QB == id);

            if (studentExamQB == null)
                return NotFound();

            return studentExamQB.ToReadDTO();
        }

        // POST: api/StudentExamQB
        [HttpPost]
        public async Task<ActionResult<StudentExamQBReadDTO>> CreateStudentExamQB(StudentExamQBCreateDTO studentExamQBCreateDTO)
        {
            var studentExamQB = studentExamQBCreateDTO.ToEntity();

            _Context.student_ExamQBs.Add(studentExamQB);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentExamQB),
                new { id = studentExamQB.Student_QB },
                studentExamQB.ToReadDTO());
        }

        // PUT: api/StudentExamQB/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentExamQB(int id, StudentExamQBUpdateDTO studentExamQBUpdateDTO)
        {
            var studentExamQB = await _Context.student_ExamQBs.FindAsync(id);

            if (studentExamQB == null)
                return NotFound();

            studentExamQB.UpdateFromDTO(studentExamQBUpdateDTO);
            await _Context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/StudentExamQB/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentExamQB(int id)
        {
            var studentExamQB = await _Context.student_ExamQBs.FindAsync(id);

            if (studentExamQB == null)
                return NotFound();

            _Context.student_ExamQBs.Remove(studentExamQB);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
    }


}

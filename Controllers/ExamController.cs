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
    public class ExamController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public ExamController(AppDB_Context context)
        {
            _Context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamReadDto>> GetExam(int id)
        {
            var exam = await _Context.exams
                .Include(e => e.Teacher) // تحميل بيانات المعلم
                .FirstOrDefaultAsync(e => e.Exam_ID == id);
            if (exam == null)
                return NotFound();
            return exam.ToReadDTO();
        }
        [HttpPost]
        public async Task<ActionResult<ExamReadDto>> CreateExam(ExamCreateDto examCreateDTO)
        {
            var exam = examCreateDTO.ToEntity();

            _Context.exams.Add(exam);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExam),
                new { id = exam.Exam_ID },
                exam.ToReadDTO());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, ExamUpdateDto examUpdateDTO)
        {
            var exam = await _Context.exams.FindAsync(id);

            if (exam == null)
                return NotFound();
            exam.UpdateFromDTO(examUpdateDTO);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _Context.exams.FindAsync(id);

            if (exam == null)
                return NotFound();
            _Context.exams.Remove(exam);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}

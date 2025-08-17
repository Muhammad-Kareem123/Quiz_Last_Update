using Exam_Api_v2.Data;
using Exam_Api_v2.DTO;
using Exam_Api_v2.Models;
using Exam_Api_v2.Converter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrueOrFalseController : ControllerBase
    {
        private readonly AppDB_Context _context;

        public TrueOrFalseController(AppDB_Context context)
        {
            _context = context;
        }

        // GET: api/TrueOrFalse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrueOrFalseReadDTO>>> GetAllQuestions()
        {
            var questions = await _context.trueOrFalses
                .Include(q => q.Question_Bank) // Include related Question_Bank data
                .ToListAsync();

            return Ok(questions.Select(q => q.ToReadDTO()));
        }

        // GET: api/TrueOrFalse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrueOrFalseReadDTO>> GetQuestion(int id)
        {
            var question = await _context.trueOrFalses
                .Include(q => q.Question_Bank) // Include related Question_Bank data
                .FirstOrDefaultAsync(q => q.Question_Bank_ID == id);

            if (question == null)
                return NotFound();

            return Ok(question.ToReadDTO());
        }

        // POST: api/TrueOrFalse
        [HttpPost]
        public async Task<ActionResult<TrueOrFalseReadDTO>> CreateQuestion(TrueOrFalseCreateDTO createDTO)
        {
            var question = createDTO.ToEntity();
            _context.trueOrFalses.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestion), new { id = question.Question_Bank_ID }, question.ToReadDTO());
        }

        // PUT: api/TrueOrFalse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, TrueOrFalseUpdateDTO updateDTO)
        {
            var question = await _context.trueOrFalses.FindAsync(id);

            if (question == null)
                return NotFound();

            question.UpdateFromDTO(updateDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TrueOrFalse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.trueOrFalses.FindAsync(id);

            if (question == null)
                return NotFound();

            _context.trueOrFalses.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

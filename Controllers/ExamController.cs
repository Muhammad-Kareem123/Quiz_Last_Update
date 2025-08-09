using Exam_Api_v2.DTOs;
using Exam_Api_v2.Repo.Exam;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Api_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepo;

        public ExamController(IExamRepository examRepo)
        {
            _examRepo = examRepo;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateExam([FromBody] CreateExamDto dto)
        {
            var result = await _examRepo.CreateExamAsync(dto);
            return Ok(result);
        }

        [HttpGet("Exams")]
        public async Task<IActionResult> GetExams()
        {
            var exams = await _examRepo.GetAllExamsAsync();
            return Ok(exams);
        }


        [HttpPost("submit")]
        public async Task<IActionResult> SubmitExam([FromBody] List<StudentAnswerDTO> studentAnswers)
        {
            var score = await _examRepo.CalculateScoreAsync(studentAnswers);
            return Ok(new { Score = score });
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, QuizUpdateDto dto)
        {
            var updated = await _examRepo.UpdateAsync(id, dto);
            if (updated == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _examRepo.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
        [HttpGet("Exam/{id}")]
        public async Task<ActionResult<ExamResponseDto>> GetById(int id)
        {
            var quiz = await _examRepo.GetByIdAsync(id);
            if (quiz == null) return NotFound();
            return Ok(quiz);
        }
        [HttpPost("submit-exam/{examId}")]
        public async Task<IActionResult> SubmitExam(int examId, [FromBody] List<StudentAnswerDTO> studentAnswers)
        {
            var result = await _examRepo.SubmitExamAsync(examId, studentAnswers);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}



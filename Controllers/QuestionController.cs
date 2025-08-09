using Exam_Api_v2.Data; // Assuming AppDbContext is here
using Exam_Api_v2.DTOs;
using Exam_Api_v2.Models;
using Exam_Api_v2.Repo.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Needed for .Include() and .SingleOrDefaultAsync()
using System;
using System.Threading.Tasks;

namespace Exam_Api_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Base route for this controller: /api/Question
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepo _questionRepo;
        private readonly AppDbContext _context; // Inject AppDbContext to fetch the question before passing to repo

        public QuestionController(IQuestionRepo questionRepo, AppDbContext context)
        {
            _questionRepo = questionRepo;
            _context = context;
        }

        /// <summary>
        /// Deletes a question by its ID.
        /// </summary>
        /// <param name="id">The ID of the question to delete.</param>
        /// <returns>No content if successful, or a not found/bad request error.</returns>
        [HttpDelete("DElete/{id}")] // DELETE: api/Question/{id}
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                await _questionRepo.DeleteQuestion(id);
                return NoContent(); // 204 No Content - indicates successful deletion
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // 404 Not Found
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.Error.WriteLine($"Error deleting question {id}: {ex.Message}");
                return StatusCode(500, "An error occurred while deleting the question."); // 500 Internal Server Error
            }
        }

        /// <summary>
        /// Edits an existing question within a specific exam.
        /// </summary>
        /// <param name="examId">The ID of the exam the question belongs to.</param>
        /// <param name="questionId">The ID of the question to edit.</param>
        /// <param name="dto">The DTO containing the updated question data.</param>
        /// <returns>The updated question if successful, or an error response.</returns>
        [HttpPut("exam/{examId}/question/Edit/{questionId}")] // PUT: api/Question/exam/{examId}/question/{questionId}
        public async Task<IActionResult> EditQuestion(int examId, int questionId, [FromBody] CreateQuestionDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Question data cannot be null.");
            }

            try
            {
                // 1. Fetch the existing question from the database using DbContext
                // We need to fetch the exam with its questions to ensure the specific question is tracked.
                var exam = await _context.Exams
                                         .Include(e => e.Questions)
                                         .SingleOrDefaultAsync(e => e.Id == examId);

                if (exam == null)
                {
                    return NotFound($"Exam with ID {examId} not found.");
                }

                var existingQuestion = exam.Questions.SingleOrDefault(q => q.Id == questionId);

                if (existingQuestion == null)
                {
                    return NotFound($"Question with ID {questionId} not found in Exam ID {examId}.");
                }

                // 2. Call the repository method to apply updates
                var updatedQuestion = await _questionRepo.EditQuestionAsync(existingQuestion, dto);

                // Return the updated question (or a DTO representation of it)
                return Ok(updatedQuestion); // 200 OK
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // 404 Not Found (e.g., if question type doesn't match)
            }
            catch (InvalidCastException ex)
            {
                // This indicates a type mismatch between the existing question and the DTO provided
                return BadRequest(ex.Message); // 400 Bad Request
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request (though this should be caught earlier)
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.Error.WriteLine($"Error editing question {questionId} in exam {examId}: {ex.Message}");
                return StatusCode(500, "An error occurred while editing the question."); // 500 Internal Server Error
            }
        }
    }
}
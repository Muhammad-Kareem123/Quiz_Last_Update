using Exam_Api_v2.Converters;
using Exam_Api_v2.Data;
using Exam_Api_v2.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public QuestionTypeController(AppDB_Context context)
        {
            _Context = context;
        }
      

            [HttpGet("{id}")]
            public async Task<ActionResult<Question_TypeReadDto>> GetQuestionType(int id)
            {
                var questionType = await _Context.questionTypes
                    .Include(q => q.Question_Banks) // تحميل الأسئلة المرتبطة
                    .FirstOrDefaultAsync(q => q.Question_Type_ID == id);

                if (questionType == null)
                    return NotFound();

                return questionType.ToReadDTO();
            }

            [HttpPost]
            public async Task<ActionResult<Question_TypeReadDto>> CreateQuestionType(Question_TypeCreateDTO questionTypeCreateDTO)
            {
                var questionType = questionTypeCreateDTO.ToEntity();

                _Context.questionTypes.Add(questionType);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetQuestionType),
                    new { id = questionType.Question_Type_ID },
                    questionType.ToReadDTO());
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateQuestionType(int id, Question_TypeUpdateDto questionTypeUpdateDTO)
            {
                var questionType = await _Context.questionTypes.FindAsync(id);

                if (questionType == null)
                    return NotFound();

                questionType.UpdateFromDTO(questionTypeUpdateDTO);
                await _Context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteQuestionType(int id)
            {
                var questionType = await _Context.questionTypes.FindAsync(id);

                if (questionType == null)
                    return NotFound();

                _Context.questionTypes.Remove(questionType);
                await _Context.SaveChangesAsync();

                return NoContent();
            }
        }

    }


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
    public class Exam_QuestionBankController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public Exam_QuestionBankController(AppDB_Context context)
        {
            _Context = context;
        }
        

            [HttpGet("{id}")]
            public async Task<ActionResult<Exam_QuestionBankReadDTO>> GetExamQuestionBank(int id)
            {
                var examQuestionBank = await _Context.exam_QuestionBanks
                    .Include(eq => eq.Exam) // تحميل بيانات الامتحان
                    .Include(eq => eq.Question_Bank) // تحميل بيانات السؤال
                    .Include(eq => eq.Teacher) // تحميل بيانات المعلم
                    .FirstOrDefaultAsync(eq => eq.Exam_QB_ID == id);

                if (examQuestionBank == null)
                    return NotFound();

                return examQuestionBank.ToReadDTO();
            }

            [HttpPost]
            public async Task<ActionResult<Exam_QuestionBankReadDTO>> CreateExamQuestionBank(Exam_QuestionBankCreateDTO examQuestionBankCreateDTO)
            {
                var examQuestionBank = examQuestionBankCreateDTO.ToEntity();

                _Context.exam_QuestionBanks.Add(examQuestionBank);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetExamQuestionBank),
                    new { id = examQuestionBank.Exam_QB_ID },
                    examQuestionBank.ToReadDTO());
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateExamQuestionBank(int id, Exam_QuestionBankUpdateDTO examQuestionBankUpdateDTO)
            {
                var examQuestionBank = await _Context.exam_QuestionBanks.FindAsync(id);

                if (examQuestionBank == null)
                    return NotFound();

                examQuestionBank.UpdateFromDTO(examQuestionBankUpdateDTO);
                await _Context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteExamQuestionBank(int id)
            {
                var examQuestionBank = await _Context.exam_QuestionBanks.FindAsync(id);

                if (examQuestionBank == null)
                    return NotFound();

                _Context.exam_QuestionBanks.Remove(examQuestionBank);
                await _Context.SaveChangesAsync();

                return NoContent();
            }
        }

    }


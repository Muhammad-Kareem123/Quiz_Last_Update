using Exam_Api_v2.Convertor;
using Exam_Api_v2.Data;
using Exam_Api_v2.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionBankController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public QuestionBankController(AppDB_Context context)
        {
            _Context = context;
        }
     

            [HttpGet("{id}")]
            public async Task<ActionResult<Question_BankReadDTO>> GetQuestionBank(int id)
            {
                var questionBank = await _Context.questionBanks
                    .Include(q => q.Teacher) // تحميل بيانات المعلم
                    .Include(q => q.QuestionType) // تحميل نوع السؤال
                    .Include(q => q.Fill_In_Gaps) // تحميل قائمة ملء الفراغات
                    .FirstOrDefaultAsync(q => q.Question_Bank_ID == id);

                if (questionBank == null)
                    return NotFound();

                return questionBank.ToReadDTO();
            }

            [HttpPost]
            public async Task<ActionResult<Question_BankReadDTO>> CreateQuestionBank(Question_BankCreateDTO questionBankCreateDTO)
            {
                var questionBank = questionBankCreateDTO.ToEntity();

                _Context.questionBanks.Add(questionBank);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetQuestionBank),
                    new { id = questionBank.Question_Bank_ID },
                    questionBank.ToReadDTO());
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateQuestionBank(int id, Question_BankUpdateDTO questionBankUpdateDTO)
            {
                var questionBank = await _Context.questionBanks.FindAsync(id);

                if (questionBank == null)
                    return NotFound();

                questionBank.UpdateFromDTO(questionBankUpdateDTO);
                await _Context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteQuestionBank(int id)
            {
                var questionBank = await _Context.questionBanks.FindAsync(id);

                if (questionBank == null)
                    return NotFound();

                _Context.questionBanks.Remove(questionBank);
                await _Context.SaveChangesAsync();

                return NoContent();
            }
        }

    }


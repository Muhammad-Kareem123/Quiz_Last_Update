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
    public class MCQ_OptionsController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public MCQ_OptionsController(AppDB_Context context)
        {
            _Context = context;
        }
       

        // GET: api/MCQOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCQ_OptionReadDto>> GetMCQOption(int id)
        {
            var option = await _Context.mCQ_Options
                .Include(o => o.Question_Banks)
                .FirstOrDefaultAsync(o => o.Option_ID == id);

            if (option == null)
                return NotFound();

            return option.ToReadDTO();
        }

        // POST: api/MCQOptions
        [HttpPost]
        public async Task<ActionResult<MCQ_OptionReadDto>> CreateMCQOption(MCQ_OptionCreateDTO mcqOptionCreateDTO)
        {
            var mcqOption = mcqOptionCreateDTO.ToEntity();

            _Context.mCQ_Options.Add(mcqOption);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMCQOption),
                new { id = mcqOption.Option_ID },
                mcqOption.ToReadDTO());
        }

        // PUT: api/MCQOptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMCQOption(int id, MCQ_OptionsUpdateDto mcqOptionUpdateDTO)
        {
            var mcqOption = await _Context.mCQ_Options.FindAsync(id);

            if (mcqOption == null)
                return NotFound();

            mcqOption.UpdateFromDTO(mcqOptionUpdateDTO);
            await _Context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/MCQOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCQOption(int id)
        {
            var mcqOption = await _Context.mCQ_Options.FindAsync(id);

            if (mcqOption == null)
                return NotFound();

            _Context.mCQ_Options.Remove(mcqOption);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
    }

}


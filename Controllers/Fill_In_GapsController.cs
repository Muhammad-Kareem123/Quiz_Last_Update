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
    public class Fill_In_GapsController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public Fill_In_GapsController(AppDB_Context context)
        {
            _Context = context;
        }

            [HttpGet("{id}")]
            public async Task<ActionResult<Fill_In_GapsReadDto>> GetFillInGap(int id)
            {
                var fillInGap = await _Context.fill_In_Gaps
                    .Include(f => f.Question_Bank) // تحميل بيانات السؤال
                    .FirstOrDefaultAsync(f => f.Gap_ID == id);

                if (fillInGap == null)
                    return NotFound();

                return fillInGap.ToReadDTO();
            }

            [HttpPost]
            public async Task<ActionResult<Fill_In_GapsReadDto>> CreateFillInGap(Fill_In_GapsCreateDTO fillInGapsCreateDTO)
            {
                var fillInGap = fillInGapsCreateDTO.ToEntity();

                _Context.fill_In_Gaps.Add(fillInGap);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetFillInGap),
                    new { id = fillInGap.Gap_ID },
                    fillInGap.ToReadDTO());
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateFillInGap(int id, Fill_In_GapsUpdateDto fillInGapsUpdateDTO)
            {
                var fillInGap = await _Context.fill_In_Gaps.FindAsync(id);

                if (fillInGap == null)
                    return NotFound();

                fillInGap.UpdateFromDTO(fillInGapsUpdateDTO);
                await _Context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteFillInGap(int id)
            {
                var fillInGap = await _Context.fill_In_Gaps.FindAsync(id);

                if (fillInGap == null)
                    return NotFound();

                _Context.fill_In_Gaps.Remove(fillInGap);
                await _Context.SaveChangesAsync();

                return NoContent();
            }
        }

    }


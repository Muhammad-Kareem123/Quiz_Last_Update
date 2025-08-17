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
    public class StatusController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public StatusController(AppDB_Context context)
        {
            _Context = context;
        }
 

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusReadDTO>> GetStatus(int id)
        {
            var status = await _Context.statuses
                .Include(s => s.Accounts)
                .Include(s => s.Logins)
                .FirstOrDefaultAsync(s => s.Status_ID == id);

            if (status == null)
                return NotFound();

            return status.ToReadDTO();
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusReadDTO>>> GetAllStatuses()
        {
            var statuses = await _Context.statuses
                .Include(s => s.Accounts)
                .Include(s => s.Logins)
                .Select(s => s.ToReadDTO())
                .ToListAsync();

            return statuses;
        }

        // POST: api/Status
        [HttpPost]
        public async Task<ActionResult<StatusReadDTO>> CreateStatus(StatusCreateDTO statusCreateDTO)
        {
            var status = statusCreateDTO.ToEntity();

            _Context.statuses.Add(status);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStatus),
                new { id = status.Status_ID },
                status.ToReadDTO());
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, StatusUpdateDTO statusUpdateDTO)
        {
            var status = await _Context.statuses.FindAsync(id);

            if (status == null)
                return NotFound();

            status.UpdateFromDTO(statusUpdateDTO);
            await _Context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _Context.statuses
                .Include(s => s.Accounts)
                .Include(s => s.Logins)
                .FirstOrDefaultAsync(s => s.Status_ID == id);

            if (status == null)
                return NotFound();

            if (status.Accounts?.Any() == true || status.Logins?.Any() == true)
                return BadRequest("Cannot delete status with associated accounts or logins");

            _Context.statuses.Remove(status);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
    }

}


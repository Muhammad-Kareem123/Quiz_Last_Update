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
    public class RolesController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public RolesController(AppDB_Context context)
        {
            _Context = context;
        }
      
            [HttpGet("{id}")]
            public async Task<ActionResult<RolesReadDTO>> GetRole(int id)
            {
                var role = await _Context.roles
                    .Include(r => r.Accounts) // تحميل الحسابات المرتبطة
                    .FirstOrDefaultAsync(r => r.Role_ID == id);

                if (role == null)
                    return NotFound();

                return role.ToReadDTO();
            }

            [HttpPost]
            public async Task<ActionResult<RolesReadDTO>> CreateRole(RolesCreateDTO roleCreateDTO)
            {
                var role = roleCreateDTO.ToEntity();

                _Context.roles.Add(role);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRole),
                    new { id = role.Role_ID },
                    role.ToReadDTO());
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateRole(int id, RolesUpdateDTO roleUpdateDTO)
            {
                var role = await _Context.roles.FindAsync(id);

                if (role == null)
                    return NotFound();

                role.UpdateFromDTO(roleUpdateDTO);
                await _Context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteRole(int id)
            {
                var role = await _Context.roles.FindAsync(id);

                if (role == null)
                    return NotFound();

                _Context.roles.Remove(role);
                await _Context.SaveChangesAsync();

                return NoContent();
            }
        }

    }


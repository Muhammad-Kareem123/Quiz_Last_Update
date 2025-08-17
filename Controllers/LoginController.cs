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
    public class LoginController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public LoginController(AppDB_Context context)
        {
            _Context = context;
        }
        

            [HttpGet("{id}")]
            public async Task<ActionResult<LoginReadDTO>> GetLogin(int id)
            {
                var login = await _Context.logins
                    .Include(l => l.Status) // تحميل بيانات الحالة
                    .Include(l => l.Account) // تحميل بيانات الحساب
                    .FirstOrDefaultAsync(l => l.Login_ID == id);

                if (login == null)
                    return NotFound();

                return login.ToReadDTO();
            }

            [HttpPost]
            public async Task<ActionResult<LoginReadDTO>> CreateLogin(LoginCreateDTO loginCreateDTO)
            {
                var login = loginCreateDTO.ToEntity();

                _Context.logins.Add(login);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetLogin),
                    new { id = login.Login_ID },
                    login.ToReadDTO());
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateLogin(int id, LoginUpdateDTO loginUpdateDTO)
            {
                var login = await _Context.logins.FindAsync(id);

                if (login == null)
                    return NotFound();

                login.UpdateFromDTO(loginUpdateDTO);
                await _Context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteLogin(int id)
            {
                var login = await _Context.logins.FindAsync(id);

                if (login == null)
                    return NotFound();

                _Context.logins.Remove(login);
                await _Context.SaveChangesAsync();

                return NoContent();
            }
        }

    }


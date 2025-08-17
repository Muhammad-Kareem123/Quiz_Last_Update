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
    public class AccountController : ControllerBase
    {
        private readonly AppDB_Context _Context;
        public AccountController(AppDB_Context context)
        {
            _Context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountReadDto>> GetAccount(int id)
        {
            var account = await _Context.accounts
                .Include(a => a.Status)
                .Include(a => a.Roles)
                .FirstOrDefaultAsync(a => a.Account_ID == id);
            if (account == null)
                return NotFound();
            return account.ToReadDTO();
        }
        [HttpPost]
        public async Task<ActionResult<AccountReadDto>> CreateAccount(AccountCreateDTO accountCreateDTO)
        {
            var account = accountCreateDTO.ToEntity();

            _Context.accounts.Add(account);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccount),
                new { id = account.Account_ID },
                account.ToReadDTO());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, AccountUpdateDto accountUpdateDTO)
        {
            var account = await _Context.accounts.FindAsync(id);

            if (account == null)
                return NotFound();
            account.UpdateFromDTO(accountUpdateDTO);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _Context.accounts.FindAsync(id);

            if (account == null)
                return NotFound();
            account.IsActive = false; // Soft delete
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}

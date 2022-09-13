using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly StoreContext _context;
        public AccountController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Account>>> List()
        {
            return await _context.Accounts.ToListAsync();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Account>> Create(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBook", new { id = account.AccountId }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Account account)
        {
            if (id != Convert.ToString(account.AccountId).ToUpper())
                return BadRequest();

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                    return NotFound();
            }

            return NoContent();
        }

        //Delete an existing book
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Guid guidId = Guid.Parse(id);

            var account = await _context.Accounts.FindAsync(guidId);

            if (account == null)
                return NotFound();

            _context.Accounts.Remove(account);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{details}")]
        public async Task<ActionResult<Account>> Details(string id)
        {
            Guid guidId = Guid.Parse(id);

            var account = await _context.Accounts.FindAsync(guidId);

            if (account == null)
                return NotFound();

            return account;
        }
        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => Convert.ToString(e.AccountId) == id);
        }
    }
}

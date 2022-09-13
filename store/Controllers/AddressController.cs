using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Controllers
{
    public class AddressController : Controller
    {
        private readonly StoreContext _context;
        public AddressController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Address>>> List()
        {
            return await _context.Addresses.ToListAsync();
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Address>> Create(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAddress", new { id = address.AddressId }, address);
        }

        //Update an existing book
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Address address)
        {
            if (id != Convert.ToString(address.AddressId).ToUpper())
                return BadRequest();

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                    return NotFound();
            }

            return NoContent();
        }

        private bool AddressExists(string id)
        {
            return _context.Addresses.Any(e => Convert.ToString(e.AddressId) == id);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            Guid guidId = Guid.Parse(id);

            var address = await _context.Addresses.FindAsync(guidId);

            if (address == null)
                return NotFound();

            _context.Addresses.Remove(address);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

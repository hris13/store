using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;
        public OrderController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Order>>> List()
        {
            return await _context.Orders.ToListAsync();
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Order>> Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }
    }
}

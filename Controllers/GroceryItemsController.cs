using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourAppName.Data;
using YourAppName.Models;

namespace YourAppName.Controllers
{
    [Route("api/[controller]")]  // Like @RequestMapping in Spring Boot
    [ApiController]              // Similar to @RestController
    public class GroceryItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Dependency injection - just like @Autowired in Spring Boot
        public GroceryItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/GroceryItems
        [HttpGet]  // Like @GetMapping in Spring Boot or app.get() in Express
        public async Task<ActionResult<IEnumerable<GroceryItem>>> GetGroceryItems()
        {
            return await _context.GroceryItems.ToListAsync();
        }

        // GET: api/GroceryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryItem>> GetGroceryItem(int id)
        {
            var item = await _context.GroceryItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();  // Returns 404
            }

            return item;
        }

        // POST: api/GroceryItems
        [HttpPost]
        public async Task<ActionResult<GroceryItem>> CreateGroceryItem(GroceryItem item)
        {
            _context.GroceryItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroceryItem), new { id = item.Id }, item);
        }

        // PUT: api/GroceryItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroceryItem(int id, GroceryItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryItemExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/GroceryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryItem(int id)
        {
            var item = await _context.GroceryItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.GroceryItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroceryItemExists(int id)
        {
            return _context.GroceryItems.Any(e => e.Id == id);
        }
    }
}
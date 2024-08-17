using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labtop.Data;
using laptop.Models;

namespace laptop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class laptopsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public laptopsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/laptops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<laptops>>> Getlaptop_data()
        {
            return await _context.laptop_data.ToListAsync();
        }

        // GET: api/laptops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<laptops>> Getlaptops(int id)
        {
            var laptops = await _context.laptop_data.FindAsync(id);

            if (laptops == null)
            {
                return NotFound();
            }

            return laptops;
        }

        // PUT: api/laptops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaptops(int id, laptops laptops)
        {
            if (id != laptops.Column_1)
            {
                return BadRequest();
            }

            _context.Entry(laptops).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laptopsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/laptops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<laptops>> Postlaptops(laptops laptops)
        {
            _context.laptop_data.Add(laptops);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (laptopsExists(laptops.Column_1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getlaptops", new { id = laptops.Column_1 }, laptops);
        }

        // DELETE: api/laptops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaptops(int id)
        {
            var laptops = await _context.laptop_data.FindAsync(id);
            if (laptops == null)
            {
                return NotFound();
            }

            _context.laptop_data.Remove(laptops);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool laptopsExists(int id)
        {
            return _context.laptop_data.Any(e => e.Column_1 == id);
        }
    }
}

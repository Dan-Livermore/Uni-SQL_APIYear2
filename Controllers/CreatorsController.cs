//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using CW2_TrailService.Models;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using TrailService.Models;

namespace TrailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorsController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public CreatorsController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/Creators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Creator>>> GetCreators()
        {
          if (_context.Creators == null)
          {
              return NotFound();
          }
            return await _context.Creators.ToListAsync();
        }

        // GET: api/Creators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Creator>> GetCreator(int id)
        {
          if (_context.Creators == null)
          {
              return NotFound();
          }
            var creator = await _context.Creators.FindAsync(id);

            if (creator == null)
            {
                return NotFound();
            }

            return creator;
        }

        // PUT: api/Creators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreator(int id, Creator creator)
        {
            if (id != creator.CreatorId)
            {
                return BadRequest();
            }

            _context.Entry(creator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreatorExists(id))
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

        // POST: api/Creators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Creator>> PostCreator(Creator creator)
        {
          if (_context.Creators == null)
          {
              return Problem("Entity set 'Comp2001DlivermoreContext.Creators'  is null.");
          }
            _context.Creators.Add(creator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreator", new { id = creator.CreatorId }, creator);
        }

        // DELETE: api/Creators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreator(int id)
        {
            if (_context.Creators == null)
            {
                return NotFound();
            }
            var creator = await _context.Creators.FindAsync(id);
            if (creator == null)
            {
                return NotFound();
            }

            _context.Creators.Remove(creator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreatorExists(int id)
        {
            return (_context.Creators?.Any(e => e.CreatorId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW2_TrailService.Models;

namespace CW2_TrailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadTrailsController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public ReadTrailsController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/Read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trail>>> GetTrails()
        {
          if (_context.Trails == null)
          {
              return NotFound();
          }
            return await _context.Trails.ToListAsync();
        }

        private bool TrailExists(int id)
        {
            return (_context.Trails?.Any(e => e.TrailId == id)).GetValueOrDefault();
        }
    }
}

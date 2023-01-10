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
    public class ReadDetailsController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public ReadDetailsController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/ReadDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> GetDetails()
        {
          if (_context.Details == null)
          {
              return NotFound();
          }
            return await _context.Details.ToListAsync();
        }

        private bool DetailExists(int id)
        {
            return (_context.Details?.Any(e => e.DetailsId == id)).GetValueOrDefault();
        }
    }
}

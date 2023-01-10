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
    public class ReadPlacesController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public ReadPlacesController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/ReadPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
          if (_context.Places == null)
          {
              return NotFound();
          }
            return await _context.Places.ToListAsync();
        }

        private bool PlaceExists(int id)
        {
            return (_context.Places?.Any(e => e.PlaceId == id)).GetValueOrDefault();
        }
    }
}

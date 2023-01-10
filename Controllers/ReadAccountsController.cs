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
    public class ReadAccountsController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public ReadAccountsController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/ReadAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            return await _context.Accounts.ToListAsync();
        }

        private bool AccountExists(string id)
        {
            return (_context.Accounts?.Any(e => e.Email == id)).GetValueOrDefault();
        }
    }
}

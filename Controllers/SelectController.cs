using CW2_TrailService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CW2_TrailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
            private readonly Comp2001DlivermoreContext _context;

            public SelectController(Comp2001DlivermoreContext context)
            {
                _context = context;
            }

            [HttpGet("SP")]
            public async Task<ActionResult<>>
 
    }
}

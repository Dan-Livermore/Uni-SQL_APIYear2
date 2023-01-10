using CW2_TrailService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CW2_TrailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public InsertController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

    }
}
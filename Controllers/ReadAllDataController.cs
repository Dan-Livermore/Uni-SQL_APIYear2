using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW2_TrailService.Models;
using CW2_TrailService.Models.DB;

namespace CW2_TrailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadAllDataController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public ReadAllDataController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/Read
        [HttpPost]
        public string GetReadAllDataOutput(ReadInput input)
        {
            var Procedure = _context.Database.ExecuteSqlRaw("EXEC CW2.ReadData " + "@ID" ,
                new SqlParameter("@ID", input.ID));



            string output = "All data in the service is being shown.";
            return output;
        }


        private bool ReadAllDataOutputExists(int id)
        {
            return (_context.ReadOutput?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
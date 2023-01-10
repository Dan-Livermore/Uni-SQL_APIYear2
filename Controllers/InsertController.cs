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
    public class InsertController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public InsertController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/Insert
        [HttpPost]
        public string GetInsertOutput(InsertInput input)
        {
            var Procedure = _context.Database.ExecuteSqlRaw("EXEC CW2.InsertData " +
                "@ID" + " , " + "@Name" + " , " + "@Description" + " , " + "@Type" + " , " + "@Area" + " , " + "@Difficulty" + " , " + "@NewMarkers" + " , " + "@Distance" + " , " + "@Elevation",
                new SqlParameter("@ID", input.ID),
                new SqlParameter("@Name", input.Name),
                new SqlParameter("@Description", input.Description),
                new SqlParameter("@Type", input.Type),
                new SqlParameter("@Area", input.Area),
                new SqlParameter("@Difficulty", input.Difficulty),
                new SqlParameter("@NewMarkers", input.NewMarkers),
                new SqlParameter("@Distance", input.Distance),
                new SqlParameter("@Elevation", input.Elevation));

            string output = "User has added the " + input.Name.ToString() + " trail to the database";
            return output;
        }


        private bool InsertOutputExists(int id)
        {
            return (_context.InsertOutput?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
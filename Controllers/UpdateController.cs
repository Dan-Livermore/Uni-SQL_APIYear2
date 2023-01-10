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
    public class UpdateController : ControllerBase
    {
        private readonly Comp2001DlivermoreContext _context;

        public UpdateController(Comp2001DlivermoreContext context)
        {
            _context = context;
        }

        // GET: api/Update
        [HttpPost]
        public string GetUpdateOutput(UpdateInput input)
        {
            var Procedure = _context.Database.ExecuteSqlRaw("EXEC CW2.UpdateData " +
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



            string output = "User has updated the " + input.Name.ToString() + " trail in the database";
            return output;
        }


        private bool UpdateOutputExists(int id)
        {
            return (_context.UpdateOutput?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

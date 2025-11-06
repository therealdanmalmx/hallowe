using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSlotController : Controller
    {
   private readonly ApplicationDbContext _db;

        public  TimeSlotController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetTimeSlots")]
        public IActionResult Get()
        {
            var timeSlots = _db.TimeSlots.ToList();

            if (timeSlots == null || !timeSlots.Any())
            {
            return NotFound("No timeSlots found");
            }

            return Ok(timeSlots);
        }
    }
}
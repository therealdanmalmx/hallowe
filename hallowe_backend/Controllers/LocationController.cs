using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Data;
using hallowe_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LocationController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var locations = _db.Locations.ToList();

            if (locations == null || !locations.Any())
            {
            return NotFound("No locations found");
            }

            return Ok(locations);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Location location)
        {
            if (location == null)
            {
            return BadRequest("Location cannot be null");
            }

            _db.Locations.Add(location);
            await _db.SaveChangesAsync();

            return CreatedAtRoute(new { id = location.Id }, location);
        }
    }
}
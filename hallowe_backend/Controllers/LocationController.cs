using System.Security.Claims;
using hallowe_backend.Data;
using hallowe_backend.DTOs;
using hallowe_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LocationController(ApplicationDbContext db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> Get()
        {
            var locations = await _db.Locations
                .Include(l => l.User) 
                .ToListAsync();

            if (!locations.Any())
                return NotFound("No locations found");

            return Ok(locations);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddNewLocationRequest addLocation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if(userId is null)
            {
                return Unauthorized();
            }
            
            if (addLocation is null)
            {
                return BadRequest("Location cannot be null");
            }

            var existingLocation = await _db.Locations
                .FirstOrDefaultAsync(l => l.StreetName == addLocation.StreetName
                    && l.StreetNumber == addLocation.StreetNumber
                    && l.PostalCode == addLocation.PostalCode);

            if (existingLocation != null)
            {
                return BadRequest("Location already registered");
            }

            var newLocation = new Location
            {
                UserId = userId!,
                Name = addLocation.Name,
                StreetName = addLocation.StreetName,
                StreetNumber = addLocation.StreetNumber,
                City = addLocation.City,
                PostalCode = addLocation.PostalCode,
                Latitude = addLocation.Latitude,
                Longitude = addLocation.Longitude,
                TrickOrTreat = addLocation.TrickOrTreat,
                Date = addLocation.Date,
                StartTime = addLocation.StartTime,
                EndTime = addLocation.EndTime,
            };

            _db.Locations.Add(newLocation);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { userId }, newLocation.Id);        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(string userId, [FromBody] UpdateLocationRequest updateLocation)
        {
            
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (currentUserId is null)
            {
                return Unauthorized();
            }
            
            if (!string.Equals(currentUserId, userId, StringComparison.Ordinal))
            {
                return Forbid();
            }

            var existingLocation = await _db.Locations.FirstOrDefaultAsync(l => l.UserId == userId);
            
            if (existingLocation is null)
            {
                return NotFound("You are not authorized to update this location");
            }
            
            existingLocation.Name = updateLocation.Name;
            existingLocation.StreetName = updateLocation.StreetName;
            existingLocation.StreetNumber = updateLocation.StreetNumber;
            existingLocation.PostalCode = updateLocation.PostalCode;
            existingLocation.City = updateLocation.City;
            existingLocation.Latitude = updateLocation.Latitude;
            existingLocation.Longitude = updateLocation.Longitude;
            existingLocation.TrickOrTreat = updateLocation.TrickOrTreat;
            existingLocation.Date = updateLocation.Date;
            existingLocation.StartTime = updateLocation.StartTime;
            existingLocation.EndTime = updateLocation.EndTime;
            
            await _db.SaveChangesAsync();

            return Ok(existingLocation);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            var getUsersAddress = await _db.Locations.FirstOrDefaultAsync(l => l.UserId == userId);

            if (getUsersAddress is null)
            {
                return NotFound("Location not found");
            }
            
            var user = await _db.Users.FindAsync(getUsersAddress.UserId);

            if (user is null)
            {
                return NotFound("User not found");
            }
            
            _db.Locations.Remove(getUsersAddress);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
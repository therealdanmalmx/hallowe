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
    public class ParticipantController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ParticipantController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetParticipants")]
        public IActionResult Get()
        {
            var participants = _db.Participants.ToList();

            if (participants == null || !participants.Any())
            {
            return NotFound("No participants found");
            }

            return Ok(participants);
        }

        [HttpPost(Name = "CreateParticipant")]
        public async Task<IActionResult> Post([FromBody] Participant participant)
        {
            if (participant == null)
            {
            return BadRequest("Participant cannot be null");
            }

            _db.Participants.Add(participant);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetParticipants", new { id = participant.Id }, participant);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {

        [HttpGet(Name = "GetParticipants")]
        public IEnumerable<Participant> Get()
        {
            // TODO: replace with your real data source (e.g., DB or repository)
            return new List<Participant>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Data;
using hallowe_backend.DTOs;
using hallowe_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisteredParticipantController : ControllerBase
    {
        private readonly IRegisteredParticipantService _registeredParticipantOrder;

        public RegisteredParticipantController(IRegisteredParticipantService registeredParticipantOrder)
        {
            _registeredParticipantOrder = registeredParticipantOrder;
        }

        // [HttpGet]
        // public async Task<ActionResult> GetRegisteredParticipants(RegisteredParticipantRequest request)
        // {
        //     return await _registeredParticipantOrder.
        // }

        [HttpPost]
        public async Task<ActionResult<RegisteredParticipantResponse>> RegisterParticipant(RegisteredParticipantRequest request)
        {
            var result = await _registeredParticipantOrder.RegisteredParticipant(request);

            if (!result.IsSuccessful)
            {
                return BadRequest(new RegisteredParticipantResponse(false, result.Errors));
            }

            return Ok(result);
        }
    }
}
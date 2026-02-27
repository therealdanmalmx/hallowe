using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Data;
using hallowe_backend.DTOs;
using hallowe_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public UserController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterResponse>>> GetAllParticipants()
        {
            var result = await _registerService.GetAllUsers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RegisterResponse>> RegisterParticipant(RegisterRequest request)
        {
            var result = await _registerService.RegisterUser(request);

            if (!result.IsSuccessful)
            {
                return BadRequest(new RegisterResponse(false, result.Errors));
            }

            return Ok(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Models.Login;
using hallowe_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IloginService _loginService;

        public LoginController(IloginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var result = await _loginService.Login(request);

            // if (!result.IsSuccessful)
            // {

            // }

            return Ok(result);
        }
    }
}
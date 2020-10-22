using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthenticationApi.Repository;
using JwtAuthenticationApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager manager;
        public AuthenticationController(IAuthenticationManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        [AllowAnonymous]
        [HttpPost("AuthenicateUser")]
        public IActionResult AuthenticateUser([FromBody]User user)
        {
            var token = manager.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}
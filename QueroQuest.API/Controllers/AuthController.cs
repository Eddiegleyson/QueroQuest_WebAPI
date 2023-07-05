using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using teste = QueroQuest.API.SecurityServices.JWTProvider;

namespace QueroQuest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        teste.AuthenticationService _addAuthentication = new teste.AuthenticationService();
        [HttpGet("Login")]
        public async Task<ActionResult> Get()
        {
            var result = _addAuthentication.GenerateJwtToken();

            return Ok(result);
        }
    }
}
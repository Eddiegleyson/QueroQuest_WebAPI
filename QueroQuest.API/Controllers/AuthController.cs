namespace QueroQuest.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using QueroQuest.Aplication.Interfaces;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // [HttpGet("AuthenticationAPI")]
    // public async Task<ActionResult> Get()
    // {
    //     var result = _authService.GenerateJwtToken();

    //     return Ok(result);
    // }
}

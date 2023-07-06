namespace QueroQuest.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using QueroQuest.Aplication.DTOs;
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

    [HttpPost("GerarTokenUsuario")]
    public async Task<ActionResult<dynamic>> Post([FromBody] UsuarioDTO usuarioDTO)
    {
        try
        {
            if (usuarioDTO is null)
            {
                return BadRequest("Payload not Found");
            }
            else
            {

                var toKenResult = _authService.GenerateJwtToken(usuarioDTO);
                if (toKenResult is not null)
                {
                    return new
                    {
                        user = usuarioDTO.Nome,
                        token = toKenResult
                    };
                }
                else
                {
                    return BadRequest("Payload not Found");
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema, ExceptionError: " + ex.StackTrace);
        }
    }
}

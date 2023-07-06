namespace QueroQuest.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Aplication.DTOs;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthService    _authService;

    public UsuarioController(IUsuarioService usuarioService, IAuthService authService)
    {
        _usuarioService = usuarioService;
        _authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
    {
        try
        {
            if (usuarioDTO is null)
            {
                return BadRequest("Payload not Found");
            }
            else
            {
                var usuarioResul = await _usuarioService.Add(usuarioDTO);
                if (usuarioResul > 0)
                {
                    var toKenResult = _authService.GenerateJwtToken(usuarioDTO);
                    if (toKenResult is not null)
                    {
                        return Ok(toKenResult); 
                    }
                    else
                    {
                        return BadRequest("Payload not Found");
                    }  
                    
                }
                else
                {
                    return BadRequest("Payload not Found");
                }

            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema, ExceptionError: "+ex.StackTrace);
        }

    }
}
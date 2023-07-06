namespace QueroQuest.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Aplication.DTOs;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthService _authService;

    public UsuarioController(IUsuarioService usuarioService, IAuthService authService)
    {
        _usuarioService = usuarioService;
        _authService = authService;
    }

    [HttpGet("GetUsuarios")]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
    {
        try
        {
            var usuariosResultDTO = await _usuarioService.GetAll();
            if (usuariosResultDTO is null)
            {
                return NotFound("Categoria não encontrada");
            }
            else
            {
                return Ok(usuariosResultDTO);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um error no sistema. ExceptionError: " + ex);
        }
    }


    [HttpPost("CadastrarUsuarioToken")]
    public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
    {
        try
        {
            /*FALTA CIRAR UM OBJETODTO QUE RETORNE USUARIO E TOKEN GERADO NA API*/
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
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema, ExceptionError: " + ex.StackTrace);
        }
    }
}
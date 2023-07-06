namespace QueroQuest.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Aplication.DTOs;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] UsuarioDTO usuarioDTO)
    {
        try
        {
            if (usuarioDTO is null)
            {
                return BadRequest("Payload not Found");
            }
            else
            {
                int categoriaId = await _usuarioService.Add(usuarioDTO);

                return categoriaId;

                /*Depois injetar a dependencia do serviço de geração de Token e retornar na criação do Usuario*/
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema, ExceptionError: "+ex.StackTrace);
        }

    }
}
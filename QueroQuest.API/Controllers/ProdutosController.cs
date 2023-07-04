namespace QueroQuest.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Aplication.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet("GetProdutoPorPreco")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutoPreco()
    {
        try
        {
            var produtoResultDTO = await _produtoService.GetProdutoPorPreco();
            if (produtoResultDTO is null)
            {
                return NotFound("Lista de Categorias não encontrada");
            }
            else
            {
                return Ok(produtoResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistema");
        }
    }

    [HttpGet("GetById", Name = "ObterProduto")]
    public ActionResult<ProdutoDTO> Get(int id)
    {
        try
        {
            var produtosResultDTO = _produtoService.GetById(id);
            if (produtosResultDTO is null)
            {
                return NotFound("Produto não encontardo.");
            }
            else
            {
                return Ok(produtosResultDTO.Result);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema.");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
    {
        try
        {
            if (produtoDto is null)
            {
                return BadRequest("Payload Not Found.");
            }
            else
            {
                int produtoId = await _produtoService.Add(produtoDto);
                return new CreatedAtRouteResult("ObterProduto", new { id = produtoId}, produtoDto);
            }
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema. ExceptionError: "+ ex.Message);
        }

    }
}

namespace QueroQuest.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Domain.Entities;
using QueroQuest.Domain.Interfaces;
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

    // [HttpGet("GetProdutoPorPreco")]
    // public ActionResult<IEnumerable<ProdutoDTO>> GetProdutoPreco()
    // {
    //     try
    //     {
    //         var produtos = _unitOfWork.ProdutoRepository.GetProdutoPorPreco().ToList();
    //         var produtosResultDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
    //         if (produtos is null)
    //         {
    //             return NotFound("Lista de Produtos POR PREÇO não encontrado");
    //         }
    //         return Ok(produtosResultDTO);
    //     }
    //     catch
    //     {
    //         return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistema");
    //     }
    // }

    // [HttpGet]
    // public ActionResult<IEnumerable<ProdutoDTO>> Get()
    // {
    //     try
    //     {
    //         var produtos = _unitOfWork.ProdutoRepository.Get().AsNoTracking().ToList();
    //         if (produtos is null)
    //         {
    //             return NotFound("Produto não encontrado");
    //         }
    //         else
    //         {
    //             var produtosResultDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
    //             return Ok(produtosResultDTO);
    //         }
    //     }
    //     catch
    //     {
    //         return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistema");
    //     }
    // }

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

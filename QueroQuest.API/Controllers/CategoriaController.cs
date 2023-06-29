
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Entities;

namespace QueroQuest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet("Produtos")]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriaProdutos()
    {
        try
        {
            var categoriaResultDTO = await _categoriaService.GetCategoriaPorProdutos();
            if (categoriaResultDTO == null)
            {
                return NotFound("Produtos não encontrados");
            }
            else
            {
                return Ok(categoriaResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistam");
        }
    }

    [HttpGet("ObterCategoriasOrdenadoPorId")]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> ObterCategoriasOrdenadoPorId()
    {
        try
        {
            var categoriaResultDTO = await _categoriaService.ObterCategoriasOrdenadoPorId();
            if (categoriaResultDTO is null)
            {
                return NotFound("Lista de Categorias não encontrada");
            }
            else
            {
                return Ok(categoriaResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistam");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        try
        {
            var categoriasResultDTO = await _categoriaService.GetAll();
            if (categoriasResultDTO is null)
            {
                return NotFound("Categoria não encontrada");
            }
            else
            {
                return Ok(categoriasResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um error no sistema.");
        }
    }

    [HttpGet("GetById", Name = "ObterCategoria")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        try
        {
            var categoriaResultDTO = _categoriaService.GetById(id);
            if (categoriaResultDTO is null)
            {
                return NotFound($"ID = {id} da Categoria não encontrada");
            }
            else
            {
                return Ok(categoriaResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistam, Id = {id}, não encontrado.");
        }

    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaParam)
    {
        try
        {
            if (categoriaParam is null)
            {
                return BadRequest("Payload not Found");
            }
            else
            {
                int categoriaId = await _categoriaService.Add(categoriaParam);
                return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaId }, categoriaParam);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema");
        }

    }
}

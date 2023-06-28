
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
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoriaService _categoriaService;
    private readonly IMapper _mapper;
    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper, ICategoriaService categoriaService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _categoriaService = categoriaService;
    }

    [HttpGet("Produtos")]
    public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriaProdutos()
    {
        try
        {
            var categoria = _categoriaService.GetCategoriaPorProdutos().ToList();
            if (categoria == null)
            {
                return NotFound("Produtos não encontrados");
            }
            else
            {
                var categoriaResultDTO = _mapper.Map<List<CategoriaDTO>>(categoria);
                return Ok(categoriaResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistam");
        }
    }

    [HttpGet("ObterCategoriasOrdenadoPorId")]
    public ActionResult<IEnumerable<CategoriaDTO>> ObterCategoriasOrdenadoPorId()
    {
        try
        {
            var categorias = _unitOfWork.CategoriaRepository.ObterCategoriasOrdenadoPorId().ToList();
            if (categorias is null)
            {
                return NotFound("Lista de Categorias não encontrada");
            }
            else
            {
                var categoriasResultDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
                return Ok(categoriasResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistam");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoriaDTO>> Get()
    {
        try
        {
            var categorias = _unitOfWork.CategoriaRepository.Get().ToList();
            if (categorias is null)
            {
                return NotFound("Categoria não encontrada");
            }
            else
            {
                var categoriasResultDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
                return Ok(categoriasResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um error no sistema.");
        }
    }

    [HttpGet("GetById", Name = "ObterCategoria")]
    public ActionResult<CategoriaDTO> Get(int id)
    {
        try
        {
            var Categoria = _unitOfWork.CategoriaRepository.GetById(p => p.CategoriaId == id);
            if (Categoria is null)
            {
                return NotFound($"ID = {id} da Categoria não encontrada");
            }
            else
            {
                var categoriaResultDTO = _mapper.Map<CategoriaDTO>(Categoria);
                return Ok(categoriaResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistam, Id = {id}, não encontrado.");
        }

    }

    [HttpPost]
    public ActionResult Post([FromBody] CategoriaDTO categoriaParam)
    {
        try
        {
            if (categoriaParam is null)
            {
                return BadRequest("Payload not Found");
            }
            else
            {
                var categoria = _mapper.Map<Categoria>(categoriaParam);
                _unitOfWork.CategoriaRepository.Add(categoria);
                _unitOfWork.Commit();

                var categoriaResultDTO = _mapper.Map<CategoriaDTO>(categoria);
                return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoriaResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema");
        }

    }
}

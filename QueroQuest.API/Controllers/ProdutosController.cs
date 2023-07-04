namespace QueroQuest.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Domain.Entities;
using QueroQuest.Domain.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProdutosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet("GetProdutoPorPreco")]
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutoPreco()
    {
        try
        {
            var produtos = _unitOfWork.ProdutoRepository.GetProdutoPorPreco().ToList();
            var produtosResultDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
            if (produtos is null)
            {
                return NotFound("Lista de Produtos POR PREÇO não encontrado");
            }
            return Ok(produtosResultDTO);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"ocorreu um problema no sistema");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProdutoDTO>> Get()
    {
        try
        {
            var produtos = _unitOfWork.ProdutoRepository.Get().AsNoTracking().ToList();
            if (produtos is null)
            {
                return NotFound("Produto não encontrado");
            }
            else
            {
                var produtosResultDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
                return Ok(produtosResultDTO);
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
            var produto = _unitOfWork.ProdutoRepository.GetById(p => p.Id == id);
            if (produto is null)
            {
                return NotFound("Produto não encontardo.");
            }
            else
            {
                var produtosResultDTO = _mapper.Map<ProdutoDTO>(produto);
                return Ok(produtosResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema.");
        }
    }
    
    [HttpPost]
    public ActionResult Post([FromBody] ProdutoDTO produtoDto)
    {
        try
        {
            if (produtoDto is null)
            {
                return BadRequest("Payload Not Found.");
            }
            else
            {
                var produto = _mapper.Map<Produto>(produtoDto);

                _unitOfWork.ProdutoRepository.Add(produto);
                _unitOfWork.Commit();

                var produtosResultDTO = _mapper.Map<ProdutoDTO>(produto);

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produtosResultDTO);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no sistema.");
        }

    }
}

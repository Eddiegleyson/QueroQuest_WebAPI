namespace QueroQuest.Aplication.Services;

using QueroQuest.Aplication.Interfaces;
using QueroQuest.Aplication.DTOs;
using System.Threading.Tasks;
using AutoMapper;
using QueroQuest.Domain.Interfaces;
using QueroQuest.Domain.Entities;

public class UsuarioService : IUsuarioService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Add(UsuarioDTO usuarioDto)
    {
        try
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            _unitOfWork.UsuarioRepository.Add(usuario);
            _unitOfWork.Commit();

            int usuarioId = usuario.Id;

            return usuarioId;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.StackTrace);
        }
    }

    public async Task<IEnumerable<UsuarioDTO>>  GetByLogin(UsuarioDTO usuarioDto)
    {
        try
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            var result = await _unitOfWork.UsuarioRepository.GetByLoginAsync(usuarioEntity);
            var usuarioResultDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(result);    
            
            return usuarioResultDTO;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.StackTrace);
        }
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAll()
    {
        try
        {
            var usariosEntity = _unitOfWork.UsuarioRepository.Get();
            var usariosResultDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usariosEntity);
            return usariosResultDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    Task IUsuarioService.Update(UsuarioDTO usuarioDto)
    {
        throw new NotImplementedException();
    }
}
namespace QueroQuest.Aplication.Mappings;

using AutoMapper;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
    }
}

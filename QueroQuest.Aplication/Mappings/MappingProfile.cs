namespace QueroQuest.Aplication.Mappings;

using AutoMapper;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
    }
}

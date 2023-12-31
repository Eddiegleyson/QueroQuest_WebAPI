namespace QueroQuest.Infra.Ioc.DependencyInjectionService;

using Microsoft.Extensions.DependencyInjection;
using QueroQuest.Domain.Interfaces;
using QueroQuest.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using QueroQuest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using QueroQuest.Aplication.Mappings;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Aplication.Services;
using QueroQuest.Aplication.Services.MessageBroker.Provider.RabbitMQ;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        string mySqlConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IProdutoRepository, ProdutoRepository>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddTransient<ICategoriaService, CategoriaService>();
        services.AddTransient<IProdutoService, ProdutoService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUsuarioService, UsuarioService>();
        services.AddTransient<IPublishService, PublishService>();
        
        var mappingConfig = new MapperConfiguration(c => { c.AddProfile(new MappingProfile()); });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
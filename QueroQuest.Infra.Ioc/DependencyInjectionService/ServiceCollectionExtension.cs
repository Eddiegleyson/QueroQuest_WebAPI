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

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        string mySqlConnection = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

        //services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection, new MySqlServerVersion(new Version(8, 0, 11))));

        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IProdutoRepository, ProdutoRepository>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        services.AddTransient<ICategoriaService, CategoriaService>();
        services.AddTransient<IProdutoService, ProdutoService>();

        var mappingConfig = new MapperConfiguration(c => {c.AddProfile(new MappingProfile());});
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        
        return services;
    }
}
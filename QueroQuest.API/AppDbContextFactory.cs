namespace QueroQuest.API;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QueroQuest.Infra.Data.Context;
using System.IO;

public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private IConfiguration _configuration;
        public AppDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Criando o DbContextOptionsBuilder manualmente
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // cria a connection string. 
            // requer a connectionstring no appsettings.json
            string mySqlConnection  = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
    
            builder.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));

            // Cria o contexto
            return new ApplicationDbContext(builder.Options);
        }
    }
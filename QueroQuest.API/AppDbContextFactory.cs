namespace QueroQuest.API;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QueroQuest.Infra.Data.Context;
using System.IO;

public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
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
            string mySqlConnection  = configuration.GetConnectionString("DefaultConnection");
            builder.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));

            // Cria o contexto
            return new ApplicationDbContext(builder.Options);
        }
    }
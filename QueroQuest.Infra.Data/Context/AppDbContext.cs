
namespace QueroQuest.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;
using QueroQuest.Domain.Entities;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

}
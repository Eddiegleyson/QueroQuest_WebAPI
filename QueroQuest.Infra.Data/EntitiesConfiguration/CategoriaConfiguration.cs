using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueroQuest.Domain.Entities;

namespace QueroQuest.Infra.Data.EntitiesConfiguration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.ImagemUrl).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Categoria(1, "Material Escolar", "material.jpg"),
            new Categoria(1, "Eletronicos", "Eletronicos.jpg"),
            new Categoria(1, "Acessórios", "acessorios.jpg")
        );
    }
}
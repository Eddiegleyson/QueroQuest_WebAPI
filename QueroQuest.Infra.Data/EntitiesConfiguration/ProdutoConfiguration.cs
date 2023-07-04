namespace QueroQuest.Infra.Data.EntitiesConfiguration;

using Microsoft.EntityFrameworkCore;
using QueroQuest.Domain.Entities;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

        builder.Property(p => p.Preco).HasPrecision(10, 2);
        builder.Property(p => p.ImagemUrl).HasMaxLength(250);
        builder.Property(p => p.Estoque).HasDefaultValue(1).IsRequired();
        builder.Property(p => p.DataCadastro).IsRequired();

        builder.HasOne(e => e.Categoria).WithMany(e => e.Produtos).HasForeignKey(e => e.CategoriaId);
    }
}
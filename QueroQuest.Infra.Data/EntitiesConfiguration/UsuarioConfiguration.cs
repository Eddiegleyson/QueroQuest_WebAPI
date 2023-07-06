using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueroQuest.Domain.Entities;

namespace QueroQuest.Infra.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Senha).HasMaxLength(10).IsRequired();
        builder.Property(p => p.FlAtivo).HasDefaultValue(1).IsRequired();

        builder.HasOne(p => p.UsuarioPerfil).WithMany(e => e.Usuarios).HasForeignKey(e => e.UsuarioPerfilId);
    }
}
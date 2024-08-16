using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Csharp_bd.Domain.Models;
namespace Csharp_bd.Core.Mapping;

public class ClienteClassMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK____Cliente");

        builder.ToTable("Cliente");

        builder.Property(e => e.ID)
            .HasColumnName("ID");

        builder.Property(e => e.Nome)
            .HasMaxLength(100)
            .HasColumnName("Nome");

        builder.Property(e => e.Senha)
            .HasMaxLength(100)
            .HasColumnName("Senha");

        builder.Property(e => e.DataNasc)
            .HasColumnName("DataNasc");

    }
}



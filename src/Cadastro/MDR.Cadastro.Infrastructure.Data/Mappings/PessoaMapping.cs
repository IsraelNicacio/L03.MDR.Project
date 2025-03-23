using MDR.Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDR.Cadastro.Infrastructure.Data.Mappings;

public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("Varchar(60)");

        builder.Property(p => p.SobreNome)
            .IsRequired()
            .HasColumnType("Varchar(60)");

        builder.Property(p => p.Idade)
            .IsRequired()
            .HasColumnType("Integer");

        builder.HasOne(o => o.Departamento)
            .WithMany(m => m.Pessoas)
            .HasForeignKey(fk => fk.DepartamentoId);

        builder.ToTable("Pessoas");
    }
}
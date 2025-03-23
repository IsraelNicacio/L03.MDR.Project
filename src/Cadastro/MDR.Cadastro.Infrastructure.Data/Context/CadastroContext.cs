using MDR.Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MDR.Cadastro.Infrastructure.Data.Context;

public class CadastroContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Departamento> Departamento { get; set; }

    public CadastroContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroContext).Assembly);
}

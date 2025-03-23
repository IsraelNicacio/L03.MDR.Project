using MDR.Cadastro.Domain.Entities;
using MDR.Cadastro.Domain.Repositories;
using MDR.Cadastro.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MDR.Cadastro.Infrastructure.Data.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly CadastroContext _context;

    public PessoaRepository(CadastroContext context) 
        => _context = context;

    public async Task<IEnumerable<Pessoa>> RecuperarPessoas() 
        => await _context.Pessoas.AsNoTracking().ToListAsync();
    public async Task<Pessoa?> RecuperarPessoaPorId(Guid id)
        => await _context.Pessoas.FirstOrDefaultAsync(f => f.Id == id);
    public async Task<IEnumerable<Pessoa>?> RecuperarPessoasPorDepartamento(Guid departamentoId)
    {
        var departamento = await _context.Departamento.FindAsync(departamentoId);
        return (departamento is not null) ? departamento.Pessoas : null;
    }
    public void AdicionarPessoa(Pessoa pessoa) => _context.Pessoas.AddAsync(pessoa);
    public void AtualizarPessoa(Pessoa pessoa) => _context.Pessoas.Update(pessoa);

    public async Task<IEnumerable<Departamento>> RecuperarDepartamentos()
        => await _context.Departamento.AsNoTracking().ToListAsync();
    public async Task<Departamento?> RecuperarDepartamentoPorId(Guid id)
        => await _context.Departamento.FindAsync(id);
    public void AdicionarDepartamento(Departamento departamento) => _context.Departamento.AddAsync(departamento);
    public void AtualizarDepartamento(Departamento departamento) => _context.Departamento.Update(departamento);
    public void Dispose() => GC.SuppressFinalize(this);
}
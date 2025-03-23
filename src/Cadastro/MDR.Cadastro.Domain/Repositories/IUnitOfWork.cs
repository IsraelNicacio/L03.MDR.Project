namespace MDR.Cadastro.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IPessoaRepository Pessoa { get; }
    Task<bool> CommitAsync();
}